using System;
using System.Collections.Generic;
using System.Text;
using Tree.Domain.DTOs.Base;

namespace Tree.Domain.DTOs
{
    public class RegionDTO 
    {
        public RegionDTO(int id, double latitude, double longitude, string description)
        {
            Id = id;
            Latitude = latitude;
            Longitude = longitude;
            Description = description;
        }

        public int Id { get; private set; }

        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        public string Description { get; private set; }
    }
}
