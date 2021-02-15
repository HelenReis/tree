using System;
using System.Collections.Generic;
using System.Text;
using Tree.Domain.Models.Base;

namespace Tree.Domain.Models
{
    public class SensorReading : ModelsBase
    {
        public short Temperature { get; private set; }

        public short Humidity { get; private set; }

        public DateTime Date { get; private set; }
    }
}
