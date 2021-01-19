using Microsoft.EntityFrameworkCore;
using Tree.Domain.Models;

namespace Tree.Data.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Device> Device { get; set; }

        public DbSet<Region> Region { get; set; }

        public DbSet<SensorReading> SensorReading { get; set; }
    }
}
