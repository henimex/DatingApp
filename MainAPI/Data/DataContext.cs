using MainAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MainAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        DbSet<Value> Values { get; set; }
    }
}
