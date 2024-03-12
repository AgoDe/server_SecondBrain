using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using SecondBrain.Data;
using SecondBrain.Models.Entities;

namespace SecondBrain.Services;

public class AccountService : CrudService<Account>
{

    public AccountService(ApplicationDbContext db , IMapper mapper) : base(db, mapper)
    {      
    }

    protected override IQueryable<Account> GetFilteredQuery(IQueryable<Account> query, string search)
    {
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(
                q => q.Name.ToLower().Contains(search.ToLower()) 
            );
        }

        return query;
    }

    protected override IQueryable<Account> GetOrderedQuery(IQueryable<Account> query, string orderBy, bool ascending = true)
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