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
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);
            modelBuilder.Entity<User>()
                .HasMany<Category>(c => c.Categories)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);    
            modelBuilder.Entity<User>()
                .Property(u => u.FullName)
                .HasMaxLength(60)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .HasMaxLength(255)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Category>()
                .HasKey(c => c.CategoryId);
            modelBuilder.Entity<Category>()
                .HasOne<User>(u => u.User)
                .WithMany(c => c.Categories)
                .HasForeignKey(u => u.UserId);
            modelBuilder.Entity<Category>()
                .Property(c => c.Description)
                .HasMaxLength(80)
                .IsRequired();
            modelBuilder.Entity<Category>()
                .Property(c=> c.Type)
                .HasMaxLength(10)
                .IsRequired();    

            modelBuilder.Entity<Account>()
                .HasKey(a => a.AccountId);
            modelBuilder.Entity<Account>()
                .HasOne<User>(u => u.User)
                .WithMany(a => a.Accounts) 
                .HasForeignKey(u => u.AccountId); 
            modelBuilder.Entity<Account>()
                .Property(a => a.Description)
                .HasMaxLength(80)
                .IsRequired();
            modelBuilder.Entity<Account>()
                .Property(a => a.Balance)
                .IsRequired();   

            modelBuilder.Entity<Transaction>()
                .HasKey(t => t.TransactionId);
            modelBuilder.Entity<Transaction>()
                .HasOne<User>(u => u.User)
                .WithMany(c => c.Transactions)
                .HasForeignKey(u => u.UserId); 
        }
    }
}
