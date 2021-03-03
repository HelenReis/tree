using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Tree.Service.Shared;

namespace Tree.Service.Queries.Region.ListDevicesByRegion
{
    class ResponseListDevicesByRegion : BaseResultController
    {
        public ResponseListDevicesByRegion(
            IEnumerable<Domain.Models.Device> devices,
            HttpStatusCode statusCode) : base(statusCode)
        {
            Devices = devices;
        }

        public IEnumerable<Domain.Models.Device> Devices { get; set; }
    }
}
