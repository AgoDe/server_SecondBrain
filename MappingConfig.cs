using AutoMapper;
using SecondBrain.Models.Dto.Account;
using SecondBrain.Models.Dto.Transaction;
using SecondBrain.Models.Entities;

namespace SecondBrain
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {   
            CreateMap<Account, AccountDto>().ReverseMap();
            CreateMap<Account, AccountIndexDto>().ReverseMap();
            CreateMap<Account, AccountCreateDto>().ReverseMap();
            CreateMap<Account, AccountUpdateDto>().ReverseMap();
            CreateMap<Transaction, TransactionDto>().ReverseMap();
            CreateMap<Transaction, TransactionIndexDto>().ReverseMap();
            CreateMap<Transaction, TransactionCreateDto>().ReverseMap();
            CreateMap<Transaction, TransactionUpdateDto>().ReverseMap();
        }
        
    }

}