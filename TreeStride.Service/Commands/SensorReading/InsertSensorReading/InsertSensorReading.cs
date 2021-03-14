using Flunt.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tree.Data.Contract;
using Tree.Data.Repositories.Transaction.UnitOfWork;

namespace Tree.Service.Commands.SensorReading.InsertSensorReading
{
    public class InsertSensorReading : IRequestHandler<ParamInsertSensorReading, ResponseInsertSensorReading>
    {
        private readonly ISensorReadingRepository _sensorReadingRepository;
        private readonly IDeviceRepository _deviceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private List<Notification> _notifications = new List<Notification>();

        public InsertSensorReading(
            ISensorReadingRepository sensorReadingRepository,
            IDeviceRepository deviceRepository,
            IUnitOfWork unitOfWork)
        {
            _sensorReadingRepository = sensorReadingRepository;
            _deviceRepository = deviceRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseInsertSensorReading> Handle(ParamInsertSensorReading request, CancellationToken cancellationToken)
        {
            try
            {
                if (!await Validations(request))
                    return new ResponseInsertSensorReading(
                        HttpStatusCode.BadRequest,
                        _notifications);

                _sensorReadingRepository.Create(
                    new Domain.Models.SensorReading(
                        temperature: request.SensorReading.Temperature,
                        humidity: request.SensorReading.Humidity,
                        date: request.SensorReading.Date,
                        deviceId: request.SensorReading.DeviceId));

                await _unitOfWork.Commit();

                return new ResponseInsertSensorReading
                    (HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        private async Task<bool> Validations(ParamInsertSensorReading request)
        {
            if (!request.SensorReading.IsValid)
            {
                _notifications.AddRange(request.SensorReading.Notifications);
                return false;
            }

            if (!await _deviceRepository.AnyAsync(request.SensorReading.DeviceId))
            {
                _notifications.Add(new Notification("DeviceId", "It must be an existing device."));
                return false;
            }

            return true;
        }
    }
}
