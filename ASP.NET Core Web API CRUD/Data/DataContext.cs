using ASP.NET_Core_Web_API_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Web_API_CRUD.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<person>persons { get; set; }
    }
}
