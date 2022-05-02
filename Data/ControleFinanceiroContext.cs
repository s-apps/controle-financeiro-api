using Microsoft.EntityFrameworkCore;
using ControleFinanceiroApi.Models;

namespace ControleFinanceiroApi.Data;
public class ControleFinanceiroContext : DbContext
{
    public ControleFinanceiroContext(DbContextOptions<ControleFinanceiroContext> options) : base(options)
    {}
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Account> Accounts { get; set; } = null!;
}