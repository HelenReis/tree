﻿using Flunt.Validations;
using System.Collections.Generic;
using Tree.Domain.Models.Base;

namespace Tree.Domain.Models
{
    public class Region : ModelsBase
    {
        public Region(double latitude, double longitude, string description)
        {
            Latitude = latitude;
            Longitude = longitude;
            Description = description;
        }

        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        public string Description { get; private set; }

        public virtual ICollection<Device> Devices { get; private set; }
    }
}
