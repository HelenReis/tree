using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using Tree.Domain.DTOs.Base;

namespace Tree.Domain.DTOs
{
    public class InsertRegionDTO : DtosBase
    {
        public InsertRegionDTO(double latitude, double longitude, string description)
        {
            AddNotifications(new Contract<string>()
                .IsNotNullOrEmpty(description, "Description", "It must be a valid description."));

            Latitude = latitude;
            Longitude = longitude;
            Description = description;
        }

        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        public string Description { get; private set; }
    }
}
