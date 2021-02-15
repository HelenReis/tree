using Tree.Domain.DTOs.Base;
using Tree.Domain.DTOs.Enums;

namespace Tree.Domain.DTOs
{
    public class RegionAverageSensorReadingDTO : DtosBase
    {
        public short Temperature { get; private set; }

        public short Humidity { get; private set; }

        public StatusSafetyColorEnum StatusSafetyColor { get; private set; }
    }
}
