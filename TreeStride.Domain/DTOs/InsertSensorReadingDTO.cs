using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using Tree.Domain.DTOs.Base;

namespace Tree.Domain.DTOs
{
    public class InsertSensorReadingDTO : ParamDtosBase
    {
        public InsertSensorReadingDTO(
            short temperature, short humidity, int deviceId)
        {
            AddNotifications(new Contract<int>()
                .IsGreaterThan(deviceId, 0, "DeviceId", "It must be a valid device."));

            Temperature = temperature;
            Humidity = humidity;
            DeviceId = deviceId;
        }

        public short Temperature { get; set; }

        public short Humidity { get; set; }

        public int DeviceId { get; set; }
    }
}
