using Tree.Domain.Models.Enums;

namespace Tree.Domain.DTOs
{
    public class RegionAverageSensorReadingDTO
    {
        public RegionAverageSensorReadingDTO(short temperature, short humidity, StatusSafetyColorEnum statusSafetyColor)
        {
            Temperature = temperature;
            Humidity = humidity;
            StatusSafetyColor = statusSafetyColor;
        }

        public short Temperature { get; private set; }

        public short Humidity { get; private set; }

        public StatusSafetyColorEnum StatusSafetyColor { get; private set; }
    }
}
