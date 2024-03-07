using AutoMapper;
using SecondBrain.Data;
using SecondBrain.Models.Entities;

namespace SecondBrain.Services;

public class SubcategoryService : CrudService<Subcategory>
{

    public SubcategoryService(ApplicationDbContext db , IMapper mapper) : base(db, mapper)
    {      
    }

    protected override IQueryable<Subcategory> GetFilteredQuery(IQueryable<Subcategory> query, string search)
    {
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(
                q => q.Name.Contains(search)
                || q.Category.Name.Contains(search)
            );
        }

        return query;
    }

    protected override IQueryable<Subcategory> GetOrderedQuery(IQueryable<Subcategory> query, string orderBy, bool ascending = true)
    {
       switch (orderBy)
       {
        case "name":
            if (ascending)
                query = query.OrderBy(q => q.Name);
            else
                query = query.OrderByDescending(q => q.Name);
            break;
        case "category":
            if (ascending)
                query = query.OrderBy(q => q.Category.Name).ThenBy(q => q.Name);
            else
                query = query.OrderByDescending(q => q.Category.Name).ThenBy(q => q.Name);
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