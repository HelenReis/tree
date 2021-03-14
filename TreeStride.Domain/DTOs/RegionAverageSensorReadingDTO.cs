using Tree.Domain.Models.Enums;

namespace Tree.Domain.DTOs
{
    public class RegionAverageSensorReadingDTO
    {
        public RegionAverageSensorReadingDTO(
            short temperature, short humidity, StatusSafetyColorEnum statusSafetyColor, string message)
        {
            Temperature = temperature;
            Humidity = humidity;
            StatusSafetyColor = statusSafetyColor;
            Message = message;
        }

        public short Temperature { get; private set; }

        public short Humidity { get; private set; }

        public StatusSafetyColorEnum StatusSafetyColor { get; private set; }

        public string Message { get; private set; }
    }
}
