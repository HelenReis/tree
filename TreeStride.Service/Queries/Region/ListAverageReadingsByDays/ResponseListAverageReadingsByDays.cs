using Flunt.Notifications;
using System.Collections.Generic;
using System.Net;
using Tree.Domain.DTOs;
using Tree.Service.Shared;

namespace Tree.Service.Queries.Region.ListAverageReadingsByDays
{
    public class ResponseListAverageReadingsByDays : BaseResultController
    {
        public ResponseListAverageReadingsByDays(
            RegionAverageSensorReadingDTO regionAverageSensorReading,
            HttpStatusCode statusCode,
            IEnumerable<Notification> errorNotifications = null) : base(statusCode, errorNotifications)
        {
            RegionAverageSensorReading = regionAverageSensorReading;
        }

        public RegionAverageSensorReadingDTO RegionAverageSensorReading { get; private set; }
    }
}
