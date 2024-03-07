using AutoMapper;
using SecondBrain.Data;
using SecondBrain.Models.Entities;

namespace SecondBrain.Services;

public class RecurringTransactionService : CrudService<RecurringTransaction>
{

    public RecurringTransactionService(ApplicationDbContext db , IMapper mapper) : base(db, mapper)
    {      
    }

    protected override IQueryable<RecurringTransaction> GetFilteredQuery(IQueryable<RecurringTransaction> query, string search)
    {
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(
                q => q.Description.Contains(search) 
                || q.Subcategory.Name.Contains(search) 
                || q.Subcategory.Category.Name.Contains(search) 
                || q.Notes.Contains(search)
            );
        }

        return query;
    }

    protected override IQueryable<RecurringTransaction> GetOrderedQuery(IQueryable<RecurringTransaction> query, string orderBy, bool ascending = true)
    {
       switch (orderBy)
       {
        case "description":
            if (ascending)
                query = query.OrderBy(q => q.Description);
            else
                query = query.OrderByDescending(q => q.Description);
            break;

        case "amount":
            if (ascending)
                query = query.OrderBy(q => q.Amount);
            else
                query = query.OrderByDescending(q => q.Amount);
            break;

        case "dayofmonth":
        if (ascending)
            query = query.OrderBy(q => q.DayOfMonth);
        else
            query = query.OrderByDescending(q => q.DayOfMonth);
        break;
        case "subcategory":
        if (ascending)
            query = query.OrderBy(q => q.Subcategory.Name);
        else
            query = query.OrderByDescending(q => q.Subcategory.Name);
        break;
        case "category":
        if (ascending)
            query = query.OrderBy(q => q.Subcategory.Category.Name).ThenBy(q => q.Subcategory.Name);
        else
            query = query.OrderByDescending(q => q.Subcategory.Category.Name).ThenBy(q => q.Subcategory.Name);
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