﻿using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Tree.Service.Shared
{
    public abstract class BaseResultController
    {
        public BaseResultController(
            HttpStatusCode statusCode,
            IEnumerable<Notification> errorNotifications = null)
        {
            StatusCode = statusCode;
            ErrorNotifications = errorNotifications;
        }

        public HttpStatusCode StatusCode { get; private set; }

        public IEnumerable<Notification> ErrorNotifications { get; private set; }
    }
}
