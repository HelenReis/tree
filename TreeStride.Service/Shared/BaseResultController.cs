using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Tree.Service.Shared
{
    public abstract class BaseResultController
    {
        protected BaseResultController(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        protected HttpStatusCode StatusCode { get; private set; }
    }
}
