using Flunt.Notifications;
using System.Collections.Generic;
using System.Net;
using Tree.Service.Shared;

namespace Tree.Service.Commands.Region.InsertRegion
{
    public class ResponseInsertRegion : BaseResultController
    {
        public ResponseInsertRegion(
            HttpStatusCode statusCode,
            IEnumerable<Notification> errorNotifications = null) : base(statusCode, errorNotifications)
        { }
    }
}
