using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Tree.Data.Contract;
using Tree.Data.Data;
using Tree.Domain.Models;

namespace Tree.Data.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly DataContext _context;

        public DeviceRepository(DataContext context)
        {
            _context = context;
        }
        
        public void Create(Device device)
        {
            _context.Add(device);
        }

        public void Update(Device device)
        {
            _context.Update(device);
        }

        public void Delete(Device device)
        {
            _context.Remove(device);
        }

        public async Task<Device> GetById(int deviceId)
        {
            return await _context.FindAsync<Device>(deviceId);
        }

        public async Task<bool> AnyAsync(int deviceId)
        {
            return await _context.Device.AnyAsync(device => device.Id == deviceId);
        }

        public IQueryable<Device> Query()
        {
            return _context.Device.AsQueryable();
        }
    }
}
