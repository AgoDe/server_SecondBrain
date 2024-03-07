using System.Linq.Expressions;
using System.Reflection;
using AutoMapper;
using MailKit.Search;
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

    public CrudService(ApplicationDbContext db , IMapper mapper)
    {
        _db = db;
        this.dbSet = _db.Set<T>();
        Mapper = mapper;
    }

    public virtual async Task<T> GetAsync(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = true)
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
            query = IncludeProperties(query, includeProperties);
        }

        return await query.FirstOrDefaultAsync();
    }


    public virtual async Task<T> GetAsync(int id,  string? includeProperties =  null, bool tracked = true)
    {
        IQueryable<T> query = GetDbSet();

        if (!tracked)
        {
            query = query.AsNoTracking();
        }

        query = query.Where(x => x.Id == id);

        if (includeProperties != null)
        {
            query = IncludeProperties(query, includeProperties);
        }

        return await query.FirstOrDefaultAsync();
    }


    public virtual async Task<List<T>> GetAllAsync(string? includeProperties = null)
    {
        IQueryable<T> query = GetDbSet();
        if (includeProperties != null)
        {
            query = IncludeProperties(query, includeProperties);
        }
        return await query.ToListAsync();
    }

    public virtual async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter, string? includeProperties = null)
    {
        IQueryable<T> query = GetDbSet();
        query = query.Where(filter);
        if (includeProperties != null)
        {
            query = IncludeProperties(query, includeProperties);
        }
        return await query.ToListAsync();
    }

    public virtual async Task<List<T>> GetAllAsync(string search, string? includeProperties = null)
    {
        IQueryable<T> query = GetDbSet();
        query = GetFilteredQuery(query, search);
        if (includeProperties != null)
        {
            query = IncludeProperties(query, includeProperties);
        }
        return await query.ToListAsync();
    }
    
    public virtual async Task<List<T>> GetAllAsync(QueryInputModel inputModel, string? includeProperties = null)
    {
        IQueryable<T> query = GetDbSet();

        query = GetFilteredQuery(query, inputModel.Search);

        if (includeProperties != null)
        {
            query = IncludeProperties(query, includeProperties);
        }

        query = GetOrderedQuery(query, inputModel.OrderBy, inputModel.Ascending);
        query = GetPagedQuery(query, inputModel.PageNumber, inputModel.PageSize);

        return await query.ToListAsync();
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

    /* Utility */
    public bool ModelExist(int id)
    {
        return dbSet.Any(x => x.Id == id);
    }
    protected virtual IQueryable<T> GetDbSet()
    {
        return this.dbSet;
    }
    protected virtual IQueryable<T> GetFilteredQuery(IQueryable<T> query, string search)
    {
        return query;
    }
    protected virtual IQueryable<T> GetOrderedQuery(IQueryable<T> query, string orderBy, bool ascending = true)
    {
        return query;
    }
    protected virtual IQueryable<T> GetPagedQuery(IQueryable<T> query, int pageNumber, int pageSize)
    {
        return query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);
    }
    protected virtual IQueryable<T> IncludeProperties(IQueryable<T> query, string includeProperties)
    {
        foreach (var prop in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(prop);
        }

        return query;
    }

}