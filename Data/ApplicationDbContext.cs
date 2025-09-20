using InvestmentAdvisor.Models;
using Microsoft.EntityFrameworkCore;

namespace InvestmentAdvisor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Ativo> Ativos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=investment_advisor.db");
        }
    }
}