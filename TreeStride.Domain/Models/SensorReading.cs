﻿using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using Tree.Domain.Models.Base;

namespace Tree.Domain.Models
{
    public class SensorReading : ModelsBase
    {
        public SensorReading(short temperature, short humidity, DateTime date, int deviceId)
        {
            Temperature = temperature;
            Humidity = humidity;
            Date = date;
            DeviceId = deviceId;
        }

        public short Temperature { get; private set; }

        public short Humidity { get; private set; }

        public DateTime Date { get; private set; }

        public int DeviceId { get; private set; }
    }
}
