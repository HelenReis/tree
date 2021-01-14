using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TreeStride.Data.Contract;
using TreeStride.Data.Data;
using TreeStride.Domain.Models;

namespace TreeStride.Data.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly DataContext _context;

        public RegionRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Region device)
        {
            _context.Add(device);
        }

        public void Update(Region device)
        {
            _context.Update(device);
        }

        public void Delete(Region device)
        {
            _context.Remove(device);
        }

        public async Task<Region> GetById(int deviceId)
        {
            return await _context.FindAsync<Region>(deviceId);
        }

        public async Task<bool> AnyAsync(int deviceId)
        {
            return await _context.Device.AnyAsync(device => device.Id == deviceId);
        }

        public IQueryable<Region> Query()
        {
            return _context.Region.AsQueryable();
        }
    }
}
