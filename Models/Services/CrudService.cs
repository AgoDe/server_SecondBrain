using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using SecondBrain.Data;
using SecondBrain.Models;
using SecondBrain.Models.Entities;

namespace SecondBrain.Services;

public class CrudService<T> where T : class, IEntity
{

    private readonly ApplicationDbContext _db;
    internal DbSet<T> dbSet;
    public IMapper Mapper;

   
    public virtual Expression<Func<T,bool>> Filter { get; set; }

    public CrudService(ApplicationDbContext db , IMapper mapper)
    {
        _db = db;
        this.dbSet = _db.Set<T>();
        Mapper = mapper;
    }

    public virtual async Task<T> GetAsync(Expression<Func<T, bool>> filter, bool tracked = true, string[]? includeProperties = null)
    {

        IQueryable<T> query = GetDbSet();
        if (!tracked)
        {
            query = query.AsNoTracking();
        }

        if (filter == null)
        {
            query = query.Where(filter);
        }
        if (includeProperties != null)
        {
            foreach (var prop in includeProperties)
            {
                query = query.Include(prop);
            }
        }

        return await query.FirstOrDefaultAsync();
    }


    public virtual async Task<T> GetAsync(int id, bool tracked = true, string[]? includeProperties = null)
    {
        IQueryable<T> query = GetDbSet();

        if (!tracked)
        {
            query = query.AsNoTracking();
        }

        query = query.Where(x => x.Id == id);

        if (includeProperties != null)
        {
            foreach (var prop in includeProperties)
            {
                query = query.Include(prop);
            }
        }

        return await query.FirstOrDefaultAsync();
    }


    public virtual async Task<List<T>> GetAllAsync()
    {
        IQueryable<T> query = GetDbSet();
        return await query.ToListAsync();
    }

    public virtual async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
    {
        IQueryable<T> query = GetDbSet();
        query = query.Where(filter);
        return await query.ToListAsync();
    }

    public virtual async Task<List<T>> GetAllAsync(QueryInputModel inputModel, string? includeProperties = null)
    {
        IQueryable<T> query = GetDbSet();

        query = GetFilteredQuery(inputModel, query);

        if (includeProperties != null)
        {
            foreach (var includeProp in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }
            
        }

        query = GetOrderedQuery(inputModel, query);
        
        query = query
            .Skip(inputModel.Offset)
            .Take(inputModel.PageSize);

        return await query.ToListAsync();
    }

    public virtual IQueryable<T> GetFilteredQuery(QueryInputModel inputModel, IQueryable<T> query)
    {
        return query;
    }

    public virtual IQueryable<T> GetOrderedQuery(QueryInputModel inputModel, IQueryable<T> query)
    {
        return query;
    }

    public virtual async Task<List<T>> GetAllAsync(
        Expression<Func<T, bool>> filter, 
        string[] includeProperties,
        bool tracked = true
    )
    {
        IQueryable<T> query = GetDbSet();
        if (filter != null)
        {
            query = query.Where(filter);
        }
        
        if (!tracked)
        {
            query = query.AsNoTracking();
        }

        if (includeProperties != null)
        {
            foreach (var prop in includeProperties)
            {
                query = query.Include(prop);
            }
        }

        List<T> results = await query.ToListAsync(); 

        return results;
    }
    
    public virtual async Task CreateAsync(T entity)
    {
        try
        {
            await dbSet.AddAsync(entity);
            await SaveAsync();
        }
        catch (PostgresException ex)
        {
            // TODO: gestire exception
        }
        catch (NpgsqlException ex)
        {
            
        }
        
    }

    public virtual async Task UpdateAsync(T entity)
    {
        try
        {
            dbSet.Update(entity);
            await SaveAsync();
        }
        catch (PostgresException ex)
        {
            Console.WriteLine(ex.Message);
            // TODO: gestire exception
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

    public virtual async Task RemoveAsync(T entity)
    { 
        try
        {
            dbSet.Remove(entity);
            await SaveAsync();
        }
        catch (PostgresException ex)
        {
            Console.WriteLine(ex.Message);
            // TODO: gestire exception
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }


    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }

    public virtual IQueryable<T> GetDbSet()
    {
        return this.dbSet;
    }

    public bool ModelExist(int id)
    {
        return dbSet.Any(x => x.Id == id);
    }

}