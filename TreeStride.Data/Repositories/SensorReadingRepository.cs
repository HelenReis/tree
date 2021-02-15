using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Tree.Data.Contract;
using Tree.Data.Data;
using Tree.Domain.Models;

namespace Tree.Data.Repositories
{
    public class SensorReadingRepository : ISensorReadingRepository
    {
        private readonly DataContext _context;

        public SensorReadingRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(SensorReading sensorReading)
        {
            _context.Add(sensorReading);
        }

        public void Update(SensorReading sensorReading)
        {
            _context.Update(sensorReading);
        }

        public void Delete(SensorReading sensorReading)
        {
            _context.Remove(sensorReading);
        }

        public async Task<SensorReading> GetById(int sensorReadingId)
        {
            return await _context.FindAsync<SensorReading>(sensorReadingId);
        }

        public async Task<bool> AnyAsync(int sensorReadingId)
        {
            return await _context.SensorReading.AnyAsync(device => device.Id == sensorReadingId);
        }

        public IQueryable<SensorReading> Query()
        {
            return _context.SensorReading.AsQueryable();
        }
    }
}
