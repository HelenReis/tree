using Flunt.Notifications;
using Flunt.Validations;
using Tree.Domain.DTOs.Base;

namespace Tree.Domain.DTOs
{
    public class InsertRegionDTO : ParamDtosBase
    {
        public InsertRegionDTO(double latitude, double longitude, string description)
        {
            AddNotifications(new Contract<string>()
                .IsNotNullOrEmpty(description, "Description", "It must be a valid description."));

            Latitude = latitude;
            Longitude = longitude;
            Description = description;
        }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Description { get; set; }
    }
}
