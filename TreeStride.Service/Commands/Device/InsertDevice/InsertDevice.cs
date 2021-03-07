using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Tree.Data.Contract;
using Tree.Data.Repositories.Transaction.UnitOfWork;

namespace Tree.Service.Commands.Device.InsertDevice
{
    public class InsertDevice : IRequestHandler<ParamInsertDevice, ResponseInsertDevice>
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InsertDevice(
            IDeviceRepository deviceRepository,
            IUnitOfWork unitOfWork)
        {
            _deviceRepository = deviceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseInsertDevice> Handle(ParamInsertDevice request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.Device.IsValid)
                    return new ResponseInsertDevice(
                        HttpStatusCode.BadRequest,
                        request.Device.Notifications);

                _deviceRepository.Create(request.Device);
                await _unitOfWork.Commit();

                return new ResponseInsertDevice(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
