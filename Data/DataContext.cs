using webapidotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace webapidotnet.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}

        public DbSet<Person> person { get; set; }
        
    }
}