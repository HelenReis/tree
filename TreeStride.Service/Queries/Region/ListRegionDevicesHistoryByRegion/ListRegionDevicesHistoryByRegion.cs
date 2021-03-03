using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Tree.Data.Contract;

namespace Tree.Service.Queries.Region.ListRegionDevicesHistoryByRegion
{
    public class ListRegionDevicesHistoryByRegion : IRequestHandler<ParamListRegionDevicesHistoryByRegion, ResponseListRegionDevicesHistoryByRegion>
    {
        private readonly IDeviceRepository _deviceRepository;

        public ListRegionDevicesHistoryByRegion(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<ResponseListRegionDevicesHistoryByRegion> Handle(ParamListRegionDevicesHistoryByRegion request, CancellationToken cancellationToken)
        {
            try
            {
                var sensorReadings = await _deviceRepository
                    .Query()
                    .Include(d => d.SensorReadings)
                    .ToListAsync();

                return new ResponseListRegionDevicesHistoryByRegion(sensorReadings, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
