using MediatR;
using System;
using System.Linq;
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
                var devices = _deviceRepository
                    .Query()
                    .ToList();

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
