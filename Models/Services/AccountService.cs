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

    

}