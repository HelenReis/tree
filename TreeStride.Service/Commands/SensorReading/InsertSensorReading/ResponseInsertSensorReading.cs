using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Tree.Service.Shared;

namespace Tree.Service.Commands.SensorReading.InsertSensorReading
{
    public class ResponseInsertSensorReading : BaseResultController
    {
        public ResponseInsertSensorReading(
            HttpStatusCode statusCode,
            IEnumerable<Notification> errorNotifications = null) : base(statusCode, errorNotifications)
        { }
    }
}
