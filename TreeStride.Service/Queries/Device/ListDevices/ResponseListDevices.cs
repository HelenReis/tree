using System.Collections.Generic;
using System.Net;
using Tree.Service.Shared;

namespace Tree.Service.Queries.Device.ListDevices
{
    public class ResponseListDevices : BaseResultController
    {
        public ResponseListDevices(
            IEnumerable<Domain.Models.Device> devices,
            HttpStatusCode statusCode) : base(statusCode)
        {
            Devices = devices;
        }

        public IEnumerable<Domain.Models.Device> Devices { get; set; }
    }
}
