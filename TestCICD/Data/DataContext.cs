using Microsoft.EntityFrameworkCore;
using TestCICD.Models;

namespace TestCICD.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
    }
}
