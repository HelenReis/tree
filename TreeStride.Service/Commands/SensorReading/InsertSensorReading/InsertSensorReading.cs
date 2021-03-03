using MediatR;
using System;
using System.Collections.Generic;
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
        private readonly IUnitOfWork _unitOfWork;

        public InsertSensorReading(
            ISensorReadingRepository sensorReadingRepository,
            IUnitOfWork unitOfWork)
        {
            _sensorReadingRepository = sensorReadingRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseInsertSensorReading> Handle(ParamInsertSensorReading request, CancellationToken cancellationToken)
        {
            try
            {
                _sensorReadingRepository.Create(request.SensorReading);
                await _unitOfWork.Commit();

                return new ResponseInsertSensorReading(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
