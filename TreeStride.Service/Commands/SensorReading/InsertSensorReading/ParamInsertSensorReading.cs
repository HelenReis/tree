using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tree.Domain.DTOs;

namespace Tree.Service.Commands.SensorReading.InsertSensorReading
{
    public class ParamInsertSensorReading : IRequest<ResponseInsertSensorReading>
    {
        public ParamInsertSensorReading(InsertSensorReadingDTO sensorReading)
        {
            SensorReading = sensorReading;
        }

        public InsertSensorReadingDTO SensorReading { get; private set; }
    }
}
