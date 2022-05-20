using ControleFinanceiroApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiroApi.Data
{
    public class ControleFinanceiroContext : DbContext
    {
        public ControleFinanceiroContext(DbContextOptions<ControleFinanceiroContext> options) : base(options)
        {}
        DbSet<User> Users { get; set; } = null!;
        DbSet<Category> Categories { get; set; } = null!;
        DbSet<Account> Accounts { get; set; } = null!;
        DbSet<Transaction> Transactions { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasKey(c => c.CategoryId);
            modelBuilder.Entity<Category>()
                .HasOne(u => u.User)
                .WithMany(c => c.Categories); 
            modelBuilder.Entity<Category>()
                .HasData(
                    new Category { 
                            CategoryId = 1, 
                            Description = "teste", 
                            Type = "teste", 
                            UserId = 1 
                        }
                    );    

            modelBuilder.Entity<Account>()
                .HasKey(a => a.AccountId);
            modelBuilder.Entity<Account>()
                .HasOne(u => u.User)
                .WithMany(a => a.Accounts);
            modelBuilder.Entity<Account>()
                .HasData(
                    new Account {
                        AccountId = 1,
                        UserId = 1,
                        Description = "teste",
                        Balance = 100.00
                    }
                );

            modelBuilder.Entity<Transaction>()
                .HasKey(t => new { t.TransactionId, t.UserId, t.CategoryId, t.AccountId });
            modelBuilder.Entity<Transaction>()    
                .Property(t => t.TransactionId).ValueGeneratedOnAdd();   
            modelBuilder.Entity<Transaction>()
                .HasOne(u => u.User)
                .WithMany(t => t.Transactions);
            modelBuilder.Entity<Transaction>()
                .HasOne(c => c.Category)
                .WithMany(t => t.Transactions);
            modelBuilder.Entity<Transaction>()
                .HasOne(a => a.Account)
                .WithMany(t => t.Transactions);    
            modelBuilder.Entity<Transaction>()
                .HasData(
                    new Transaction {
                        TransactionId = 1,
                        UserId = 1,
                        CategoryId = 1,
                        AccountId = 1,
                        RegistrationDate = DateTime.Now,
                        ExpirationDate = null,
                        PaymentDate = null,
                        Image = null,
                        Amount = 100.00
                    }
                ); 

            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);
            modelBuilder.Entity<User>()
                .HasData(
                    new User {
                        UserId = 1,
                        FullName = "teste",
                        Email = "teste",
                        Password = "teste",
                        CreatedDate = DateTime.Now,
                        UpdatedDate = null
                    }
                );    
            modelBuilder.Entity<User>()
                .HasMany<Category>(c => c.Categories)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);    
            modelBuilder.Entity<User>()
                .HasMany<Account>(a => a.Accounts)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .HasMany<Transaction>(t => t.Transactions)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);                     
        }
    }
}
