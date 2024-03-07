
using AutoMapper;
using SecondBrain.Data;

using SecondBrain.Models.Entities;

namespace SecondBrain.Services;

public class CategoryService : CrudService<Category>
{

    public CategoryService(ApplicationDbContext db , IMapper mapper) : base(db, mapper)
    {      
    }

    protected override IQueryable<Category> GetFilteredQuery(IQueryable<Category> query, string search)
    {
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(
                q => q.Name.Contains(search) 
            );
        }

        return query;
    }

    protected override IQueryable<Category> GetOrderedQuery(IQueryable<Category> query, string orderBy, bool ascending = true)
    {
       switch (orderBy)
       {
        case "name":
            if (ascending)
                query = query.OrderBy(q => q.Name);
            else
                query = query.OrderByDescending(q => q.Name);
            break;
        
        default:
            if (ascending)
                query = query.OrderBy(q => q.Id);
            else
                query = query.OrderByDescending(q => q.Id);
            break;
       }

       return query;
    }

    

}