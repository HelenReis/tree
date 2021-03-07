using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using Tree.Domain.Models.Base;

namespace Tree.Domain.Models
{
    public class SensorReading : ModelsBase
    {
        public SensorReading(short temperature, short humidity, DateTime date)
        {
            AddNotifications(new Contract<DateTime>()
                .IsGreaterOrEqualsThan(date, DateTime.Now, "Date", "Date must be entered in real time."));

            Temperature = temperature;
            Humidity = humidity;
            Date = date;
        }

        public short Temperature { get; private set; }

        public short Humidity { get; private set; }

        public DateTime Date { get; private set; }
    }
}
