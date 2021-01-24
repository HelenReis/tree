using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tree.Data.Contract;

namespace Tree.Service.Queries.Device.QueryListDevices
{
    public class QueryListDevices : IRequestHandler<ParamListDevices, ResponseListDevices>
    {
        private readonly IDeviceRepository _deviceRepository;
        public QueryListDevices(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<ResponseListDevices> Handle(ParamListDevices request, CancellationToken cancellationToken)
        {
            try
            {
                var device = await _deviceRepository
                    .GetById(request.DeviceId);

                return new ResponseListDevices
                {
                    Device = device
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
