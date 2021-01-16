using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TreeStride.Data.Contract;
using TreeStride.Service.Queries.Base;

namespace TreeStride.Service.Queries.QueryListDevices
{
    public class QueryListDevices : IQueryExecutor<ParamListDevices, ResponseListDevices>
    {
        private readonly IDeviceRepository _deviceRepository;
        public QueryListDevices(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<ResponseListDevices> ExecuteQuery(ParamListDevices param)
        {
            try
            {
                var devices = await _deviceRepository
                    .Query()
                    .Where(d => d.Id == param.DeviceId)
                    .ToListAsync();

                return new ResponseListDevices
                {
                    Devices = devices
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
