using System;
using System.Collections.Generic;
using System.Text;
using TreeStride.Domain.DTOs.Base;

namespace TreeStride.Domain.DTOs
{
    public class RegionDTO : DtosBase
    {
        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        public ICollection<DeviceDTO> Devices { get; private set; }
    }
}
