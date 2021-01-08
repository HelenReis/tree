using Microsoft.EntityFrameworkCore;
using TreeStride.Domain.Models;

namespace TreeStride.Data.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Device> Device { get; set; }

        public DbSet<Region> Region { get; set; }

        public DbSet<SensorReading> SensorReading { get; set; }
    }
}
