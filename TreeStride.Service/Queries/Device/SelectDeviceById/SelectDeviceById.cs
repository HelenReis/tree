using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Tree.Data.Contract;

namespace Tree.Service.Queries.Device.SelectDeviceById
{
    public class SelectDeviceById : IRequestHandler<ParamSelectDeviceById, ResponseSelectDeviceById>
    {
        private readonly IDeviceRepository _deviceRepository;

        public SelectDeviceById(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<ResponseSelectDeviceById> Handle(ParamSelectDeviceById request, CancellationToken cancellationToken)
        {
            try
            {
                var device = await _deviceRepository
                    .GetById(request.DeviceId);

                return new ResponseSelectDeviceById(device, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
