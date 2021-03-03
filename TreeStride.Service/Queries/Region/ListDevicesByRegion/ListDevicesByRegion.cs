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

namespace Tree.Service.Queries.Region.ListDevicesByRegion
{
    class ListDevicesByRegion : IRequestHandler<ParamListDevicesByRegion, ResponseListDevicesByRegion>
    {
        private readonly IRegionRepository _regionRepository;
        public ListDevicesByRegion(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public async Task<ResponseListDevicesByRegion> Handle(ParamListDevicesByRegion request, CancellationToken cancellationToken)
        {
            try
            {
                var devices = await _regionRepository
                    .Query()
                    .Where(region => region.Id == request.RegionId)
                    .Select(region => region.Devices)
                    .FirstOrDefaultAsync();

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
