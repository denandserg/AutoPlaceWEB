using Microsoft.EntityFrameworkCore;

namespace HelloAngularApp.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()

        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=dwayne-pc;Database=AutoPlace;Trusted_Connection=True; MultipleActiveResultSets=True;");
        }

        public DbSet<Car> Cars { get; set; }
    }
}