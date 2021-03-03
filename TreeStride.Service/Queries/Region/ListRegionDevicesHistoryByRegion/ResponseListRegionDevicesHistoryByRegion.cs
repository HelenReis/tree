using System.Collections.Generic;
using System.Net;
using Tree.Service.Shared;

namespace Tree.Service.Queries.Region.ListRegionDevicesHistoryByRegion
{
    public class ResponseListRegionDevicesHistoryByRegion : BaseResultController
    {
        public ResponseListRegionDevicesHistoryByRegion(
            IEnumerable<Domain.Models.Device> devices,
            HttpStatusCode statusCode) : base(statusCode)
        {
            Devices = devices;
        }
        public IEnumerable<Domain.Models.Device> Devices { get; private set; }
    }
}
