using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tree.Service.Commands.SensorReading.InsertSensorReading
{
    public class ParamInsertSensorReading : IRequest<ResponseInsertSensorReading>
    {
        public ParamInsertSensorReading(Domain.Models.SensorReading sensorReading)
        {
            SensorReading = sensorReading;
        }

        public Domain.Models.SensorReading SensorReading { get; private set; }
    }
}
