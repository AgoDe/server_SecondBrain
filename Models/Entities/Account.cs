using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Slugify;

namespace SecondBrain.Models.Entities
{
    public class Account : Entity
    {   
        private readonly SlugHelper _slugify;
        private string _name;

        public Account()
        {
            _slugify = new SlugHelper();
        }

        public string Name 
        { 
            get => _name;
            set 
            {
                _name = value;
                Slug = _slugify.GenerateSlug(value);    
            } 
        }
        public string Slug { get; set; }
        public float InitialBalance { get; set; }

        public int UserId { get; set; }
        public ApplicationUser? User { get; set; } = null!;

        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        public List<RecurringTransaction> RecurringTransactions { get; set; } = new List<RecurringTransaction>();
        public List<ExpectedTransaction> ExpectedTransactions { get; set; } = new List<ExpectedTransaction>();
        public List<Goal> Goals { get; set; } = new List<Goal>();
        public List<MoneyTransfer> IncomeTransfers { get; set; } = new List<MoneyTransfer>();
        public List<MoneyTransfer> OutcomeTransfers { get; set; } = new List<MoneyTransfer>();



    }
}