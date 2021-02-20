using System.Collections.Generic;
using Tree.Domain.DTOs;

namespace Tree.Service.Queries.Region.ListAverageReadingsByDays
{
    public class ResponseListAverageReadingsByDays
    {
        public ResponseListAverageReadingsByDays(RegionAverageSensorReadingDTO regionAverageSensorReading)
        {
            RegionAverageSensorReading = regionAverageSensorReading;
        }

        public RegionAverageSensorReadingDTO RegionAverageSensorReading { get; set; }
    }
}
