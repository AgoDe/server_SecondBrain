using System.Linq.Expressions;
using AutoMapper;
using SecondBrain.Data;
using SecondBrain.Models;
using SecondBrain.Models.Entities;

namespace SecondBrain.Services;

public class TransactionService : CrudService<Transaction>
{

    public TransactionService(ApplicationDbContext db , IMapper mapper) : base(db, mapper)
    {      
    }

    public override IQueryable<Transaction> GetFilteredQuery(QueryInputModel inputModel, IQueryable<Transaction> query)
    {
        if (!string.IsNullOrEmpty(inputModel.Search))
        {
            query = query.Where(
                q => q.Description.Contains(inputModel.Search) 
                || q.Subcategory.Name.Contains(inputModel.Search) 
                || q.Subcategory.Category.Name.Contains(inputModel.Search) 
                || q.Notes.Contains(inputModel.Search)
            );
        }

        return query;
    }

    public override IQueryable<Transaction> GetOrderedQuery(QueryInputModel inputModel, IQueryable<Transaction> query)
    {
       switch (inputModel.OrderBy)
       {
        case "description":
            if (inputModel.Ascending)
                query = query.OrderBy(q => q.Description);
            else
                query = query.OrderByDescending(q => q.Description);
            break;

        case "amount":
            if (inputModel.Ascending)
                query = query.OrderBy(q => q.Amount);
            else
                query = query.OrderByDescending(q => q.Amount);
            break;

        case "date":
        if (inputModel.Ascending)
            query = query.OrderBy(q => q.Date);
        else
            query = query.OrderByDescending(q => q.Date);
        break;
        
        default:
            if (inputModel.Ascending)
                query = query.OrderBy(q => q.Id);
            else
                query = query.OrderByDescending(q => q.Id);
            break;
       }

       return query;
    }

    

}