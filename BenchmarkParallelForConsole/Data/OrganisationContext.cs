using BenchmarkParallelForConsole.Model;
using Microsoft.EntityFrameworkCore;

namespace BenchmarkParallelForConsole.Data
{
    public class OrganisationContext : DbContext
    {         
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-QG1GTJV1\SQLEXPRESS;Database=Organisations;Integrated Security=true");
        }

        public DbSet<Organisation> Organisation { get; set; }
    }
}
