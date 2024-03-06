using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecondBrain.Models.Entities;


namespace SecondBrain.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override async void OnModelCreating(ModelBuilder builder)
    {
        
        base.OnModelCreating(builder);

        builder.Entity<Account>()
            .HasMany(x => x.OutcomeTransfers)
            .WithOne(x => x.OriginAccount)
            .HasForeignKey(x => x.OriginAccountId)
            .IsRequired();

        builder.Entity<Account>()
            .HasMany(x => x.IncomeTransfers)
            .WithOne(x => x.DestinationAccount)
            .HasForeignKey(x => x.DestinationAccountId)
            .IsRequired();

        
    }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<ApplicationRole> ApplicationRoles { get; set; }
    public DbSet<Account> Account { get; set; }
    public DbSet<ExpectedTransaction> ExpectedTransaction { get; set; }
    public DbSet<RecurringTransaction> RecurringTransaction { get; set; }
    public DbSet<Transaction> Transaction { get; set; }
    public DbSet<Subcategory> Subcategory { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Goal> Goal { get; set; }
    public DbSet<MoneyTransfer> MoneyTransfer { get; set; }
    

}
