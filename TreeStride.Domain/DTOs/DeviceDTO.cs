using System;
using System.Collections.Generic;
using System.Text;
using Tree.Domain.DTOs.Base;

namespace Tree.Domain.DTOs
{
    public class DeviceDTO
    {
        public DeviceDTO(int id, bool enabled, IEnumerable<SensorReadingDTO> sensorReading)
        {
            Id = id;
            Enabled = enabled;
            SensorReading = sensorReading;
        }

        public int Id { get; private set; }

        public bool Enabled { get; private set; }

        public IEnumerable<SensorReadingDTO> SensorReading { get; private set; }
    }
}
