using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tree.Data.Contract;

namespace Tree.Service.Queries.Device.ListDevices
{
    public class ListDevices : IRequestHandler<ParamListDevices, ResponseListDevices>
    {
        private readonly IDeviceRepository _deviceRepository;

        public ListDevices(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<ResponseListDevices> Handle(ParamListDevices request, CancellationToken cancellationToken)
        {
            try
            {
                var devices = await _deviceRepository
                    .Query()
                    .Take(request.Limit)
                    .Skip(request.Skip)
                    .ToListAsync();

                return new ResponseListDevices { Devices = devices };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
