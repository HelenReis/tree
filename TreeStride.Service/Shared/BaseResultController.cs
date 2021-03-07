using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Tree.Service.Shared
{
    public abstract class BaseResultController
    {
        protected BaseResultController(
            HttpStatusCode statusCode,
            IEnumerable<Notification> errorNotifications = null)
        {
            StatusCode = statusCode;
            ErrorNotifications = errorNotifications;
        }

        protected HttpStatusCode StatusCode { get; private set; }

        protected IEnumerable<Notification> ErrorNotifications { get; private set; }
    }
}
