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
            short temperature, short humidity, DateTime date, int deviceId)
        {
            AddNotifications(new Contract<DateTime>()
                .IsGreaterOrEqualsThan(date, DateTime.Now.AddHours(-2), "Date", "Date must be entered in real time."));

            AddNotifications(new Contract<int>()
                .IsGreaterThan(deviceId, 0, "DeviceId", "It must be a valid device."));

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
