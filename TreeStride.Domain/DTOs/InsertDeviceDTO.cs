using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using Tree.Domain.DTOs.Base;

namespace Tree.Domain.DTOs
{
    public class InsertDeviceDTO : ParamDtosBase
    {
        public InsertDeviceDTO(bool enabled, int regionId)
        {
            AddNotifications(new Contract<int>()
                .IsGreaterThan(regionId, 0, "RegionId", "It must be an existing region.")
        );
            Enabled = enabled;
            RegionId = regionId;
        }

        public bool Enabled { get; private set; }

        public int RegionId { get; private set; }
    }
}
