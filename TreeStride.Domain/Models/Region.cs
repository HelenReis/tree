using System;
using System.Collections.Generic;
using System.Text;
using TreeStride.Domain.Models.Base;

namespace TreeStride.Domain.Models
{
    public class Region : ModelsBase
    {
        public Region(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        public virtual ICollection<Device> Devices { get; private set; }
    }
}
