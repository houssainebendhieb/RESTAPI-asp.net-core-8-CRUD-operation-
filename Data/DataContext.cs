using Microsoft.EntityFrameworkCore;
using WebApplication2.Entities;

namespace WebApplication2.NewFolder
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

            public DbSet<Personee>Personees { get; set; }


    }
}
