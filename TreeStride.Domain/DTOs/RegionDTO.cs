using System;
using System.Collections.Generic;
using System.Text;
using Tree.Domain.DTOs.Base;

namespace Tree.Domain.DTOs
{
    public class RegionDTO : DtosBase
    {
        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        public ICollection<DeviceDTO> Devices { get; private set; }
    }
}
