﻿using System;
using System.Collections.Generic;
using System.Text;
using TreeStride.Domain.Models.Base;

namespace TreeStride.Domain.Models
{
    public class Device : ModelsBase
    {
        public bool Enabled { get; private set; }

        public int RegionId { get; private set; }

        public virtual Region Region { get; private set; }

        public virtual ICollection<SensorReading> SensorReadings { get; private set; }
    }
}
