using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeStride.Domain.Models;

namespace TreeStride.Data.Contract
{
    public interface IDeviceRepository
    {
        void Create(Device device);

        void Update(Device device);

        void Delete(Device device);

        Task<Device> GetById(int deviceId);

        Task<bool> AnyAsync(int deviceId);

        IQueryable<Device> Query();
    }
}
