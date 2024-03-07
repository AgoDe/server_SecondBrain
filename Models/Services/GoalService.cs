using System.Linq.Expressions;
using AutoMapper;
using SecondBrain.Data;
using SecondBrain.Models;
using SecondBrain.Models.Entities;

namespace SecondBrain.Services;

public class GoalService : CrudService<Goal>
{

    public GoalService(ApplicationDbContext db , IMapper mapper) : base(db, mapper)
    {      
    }

    protected override IQueryable<Goal> GetFilteredQuery(IQueryable<Goal> query, string search)
    {
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(
                q => q.Description.Contains(search) 
            );
        }

        return query;
    }

    protected override IQueryable<Goal> GetOrderedQuery(IQueryable<Goal> query, string orderBy, bool ascending = true)
    {
       switch (orderBy)
       {
        case "description":
            if (ascending)
                query = query.OrderBy(q => q.Description);
            else
                query = query.OrderByDescending(q => q.Description);
            break;

        case "account":
            if (ascending)
                query = query.OrderBy(q => q.Account.Name);
            else
                query = query.OrderByDescending(q => q.Account.Name);
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