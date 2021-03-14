using System;
using System.Collections.Generic;
using System.Text;
using Tree.Domain.DTOs.Base;

namespace Tree.Domain.DTOs
{
    public class SensorReadingDTO
    {
        public SensorReadingDTO(int id, short temperature, short humidity, DateTime date)
        {
            Id = id;
            Temperature = temperature;
            Humidity = humidity;
            Date = date;
        }

        public int Id { get; private set; }

        public short Temperature { get; private set; }

        public short Humidity { get; private set; }

        public DateTime Date { get; private set; }
    }
}
