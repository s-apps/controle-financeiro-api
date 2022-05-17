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
        }
    }
}
