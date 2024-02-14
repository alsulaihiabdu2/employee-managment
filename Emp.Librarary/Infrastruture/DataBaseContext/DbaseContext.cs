using Emp.Librarary.Domain;
using Microsoft.EntityFrameworkCore;

namespace Emp.Librarary.Infrastruture.DataBaseContext
{
    public class DbaseContext : DbContext
    {

        public virtual DbSet<Employee> employee { get; set; }

        public DbaseContext(DbContextOptions<DbaseContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EmployeeDb;Trusted_Connection=True;");
        }
    }
}
