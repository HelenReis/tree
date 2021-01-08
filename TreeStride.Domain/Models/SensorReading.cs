using System;
using System.Collections.Generic;
using System.Text;
using TreeStride.Domain.Models.Base;

namespace TreeStride.Domain.Models
{
    public class SensorReading : ModelsBase
    {
        public short Temperature { get; private set; }

        public short Humidity { get; private set; }
    }
}
