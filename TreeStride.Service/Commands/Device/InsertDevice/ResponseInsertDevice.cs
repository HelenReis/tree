using System.Collections.Generic;
using System.Net;
using Tree.Service.Shared;

namespace Tree.Service.Commands.Device.InsertDevice
{
    public class ResponseInsertDevice : BaseResultController
    {
        public ResponseInsertDevice(HttpStatusCode statusCode) : base(statusCode)
        { }
    }
}
