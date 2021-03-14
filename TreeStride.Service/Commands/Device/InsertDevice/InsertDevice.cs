using Flunt.Notifications;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        private readonly IRegionRepository _regionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private List<Notification> _notifications = new List<Notification>();

        public InsertDevice(
            IDeviceRepository deviceRepository,
            IRegionRepository regionRepository,
            IUnitOfWork unitOfWork)
        {
            _deviceRepository = deviceRepository;
            _regionRepository = regionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseInsertDevice> Handle(ParamInsertDevice request, CancellationToken cancellationToken)
        {
            try
            {
                if (!await Validations(request))
                    return new ResponseInsertDevice(
                        HttpStatusCode.BadRequest,
                        _notifications);

                _deviceRepository.Create(
                    new Domain.Models.Device(request.Device.Enabled, request.Device.RegionId));
                await _unitOfWork.Commit();

                return new ResponseInsertDevice(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        private async Task<bool> Validations(ParamInsertDevice request)
        {
            if (!request.Device.IsValid)
            {
                _notifications.AddRange(request.Device.Notifications);
                return false;
            }

            if (!await _regionRepository.AnyAsync(request.Device.RegionId))
            {
                _notifications.Add(new Notification("RegionId", "It must be an existing region."));
                return false;
            }

            return true;
        }
    }
}
