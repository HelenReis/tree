using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeStride.Data.Contract;
using TreeStride.Data.Data;
using TreeStride.Domain.Models;

namespace TreeStride.Data.Repositories
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
