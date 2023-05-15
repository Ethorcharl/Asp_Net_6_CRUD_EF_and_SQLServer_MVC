using Asp_Net_6_CRUD_EF_and_SQLServer.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Asp_Net_6_CRUD_EF_and_SQLServer.Data
{
    public class MVCDbContext : DbContext
    {
        public MVCDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
