using AutoMapper;
using SecondBrain.Data;
using SecondBrain.Models.Entities;

namespace SecondBrain.Services;

public class MoneyTransferService : CrudService<MoneyTransfer>
{

    public MoneyTransferService(ApplicationDbContext db , IMapper mapper) : base(db, mapper)
    {      
    }

    protected override IQueryable<MoneyTransfer> GetFilteredQuery(IQueryable<MoneyTransfer> query, string search)
    {
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(
                q => q.Description.Contains(search) 
                || q.OriginAccount.Name.Contains(search) 
                || q.DestinationAccount.Name.Contains(search) 
                || q.Notes.Contains(search)
            );
        }

        return query;
    }

    protected override IQueryable<MoneyTransfer> GetOrderedQuery(IQueryable<MoneyTransfer> query, string orderBy, bool ascending = true)
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

        case "date":
        if (ascending)
            query = query.OrderBy(q => q.Date);
        else
            query = query.OrderByDescending(q => q.Date);
        break;

        case "originaccount":
        if (ascending)
            query = query.OrderBy(q => q.OriginAccount.Name);
        else
            query = query.OrderByDescending(q => q.OriginAccount.Name);
        break;
        case "destinationaccount":
        if (ascending)
            query = query.OrderBy(q => q.DestinationAccount.Name);
        else
            query = query.OrderByDescending(q => q.DestinationAccount.Name);
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