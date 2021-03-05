using System.Collections.Generic;
using System.Net;
using Tree.Service.Shared;

namespace Tree.Service.Queries.Device.SelectDeviceById
{
    public class ResponseSelectDeviceById : BaseResultController
    {
        public ResponseSelectDeviceById(
            Domain.Models.Device device,
            HttpStatusCode statusCode) : base(statusCode)
        {
            Device = device;
        }

        public Domain.Models.Device Device { get; private set; }
    }
}
