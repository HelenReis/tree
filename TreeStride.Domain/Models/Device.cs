﻿using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using Tree.Domain.Models.Base;

namespace Tree.Domain.Models
{
    public class Device : ModelsBase
    {
        public Device(bool enabled, int regionId)
        {
            AddNotifications(new Contract<int>()
                .IsGreaterThan(regionId, 0, "RegionId", "It must be an existing region.")
        );

            Enabled = enabled;
            RegionId = regionId;
        }

        public bool Enabled { get; private set; }

        public int RegionId { get; private set; }

        public virtual Region Region { get; private set; }

        public virtual ICollection<SensorReading> SensorReadings { get; private set; }
    }
}
