using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using Tree.Domain.DTOs.Base;

namespace Tree.Domain.DTOs
{
    public class InsertSensorReadingDTO : DtosBase
    {
        public InsertSensorReadingDTO(short temperature, short humidity, DateTime date)
        {
            AddNotifications(new Contract<DateTime>()
                .IsGreaterOrEqualsThan(date, DateTime.Now, "Date", "Dat,e must be entered in real time."));

            Temperature = temperature;
            Humidity = humidity;
            Date = date;
        }

        public short Temperature { get; private set; }

        public short Humidity { get; private set; }

        public DateTime Date { get; private set; }
    }
}
