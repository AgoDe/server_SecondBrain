using AutoMapper;
using SecondBrain.Models.Dto.Account;
using SecondBrain.Models.Dto.Category;
using SecondBrain.Models.Dto.ExpectedTransaction;
using SecondBrain.Models.Dto.Goal;
using SecondBrain.Models.Dto.MoneyTransfer;
using SecondBrain.Models.Dto.RecurringTransaction;
using SecondBrain.Models.Dto.Subcategory;
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
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryIndexDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateDto>().ReverseMap();
            CreateMap<Subcategory, SubcategoryDto>().ReverseMap();
            CreateMap<Subcategory, SubcategoryIndexDto>().ReverseMap();
            CreateMap<Subcategory, SubcategoryCreateDto>().ReverseMap();
            CreateMap<Subcategory, SubcategoryUpdateDto>().ReverseMap();
            CreateMap<Transaction, TransactionDto>().ReverseMap();
            CreateMap<Transaction, TransactionIndexDto>().ReverseMap();
            CreateMap<Transaction, TransactionCreateDto>().ReverseMap();
            CreateMap<Transaction, TransactionUpdateDto>().ReverseMap();
            CreateMap<ExpectedTransaction, ExpectedTransactionDto>().ReverseMap();
            CreateMap<ExpectedTransaction, ExpectedTransactionIndexDto>().ReverseMap();
            CreateMap<ExpectedTransaction, ExpectedTransactionCreateDto>().ReverseMap();
            CreateMap<ExpectedTransaction, ExpectedTransactionUpdateDto>().ReverseMap();
            CreateMap<RecurringTransaction, RecurringTransactionDto>().ReverseMap();
            CreateMap<RecurringTransaction, RecurringTransactionIndexDto>().ReverseMap();
            CreateMap<RecurringTransaction, RecurringTransactionCreateDto>().ReverseMap();
            CreateMap<RecurringTransaction, RecurringTransactionUpdateDto>().ReverseMap();
            CreateMap<MoneyTransfer, MoneyTransferDto>().ReverseMap();
            CreateMap<MoneyTransfer, MoneyTransferIndexDto>().ReverseMap();
            CreateMap<MoneyTransfer, MoneyTransferCreateDto>().ReverseMap();
            CreateMap<MoneyTransfer, MoneyTransferUpdateDto>().ReverseMap();
            CreateMap<Goal, GoalDto>().ReverseMap();
            CreateMap<Goal, GoalIndexDto>().ReverseMap();
            CreateMap<Goal, GoalCreateDto>().ReverseMap();
            CreateMap<Goal, GoalUpdateDto>().ReverseMap();
        }
        
    }

}