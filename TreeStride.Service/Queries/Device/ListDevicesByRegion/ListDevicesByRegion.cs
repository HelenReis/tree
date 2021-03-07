using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tree.Data.Contract;

namespace Tree.Service.Queries.Device.ListDevicesByRegion
{
    class ListDevicesByRegion : IRequestHandler<ParamListDevicesByRegion, ResponseListDevicesByRegion>
    {
        private readonly IDeviceRepository _deviceRepository;

        public ListDevicesByRegion(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<ResponseListDevicesByRegion> Handle(ParamListDevicesByRegion request, CancellationToken cancellationToken)
        {
            try
            {
                var devices = await _deviceRepository
                    .Query()
                    .Where(device => device.RegionId == request.RegionId)
                    .ToListAsync();

                return new ResponseListDevicesByRegion(devices, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
