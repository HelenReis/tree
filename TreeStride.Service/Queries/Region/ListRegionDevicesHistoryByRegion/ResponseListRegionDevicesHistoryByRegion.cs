using System.Collections.Generic;
using System.Net;
using Tree.Domain.DTOs;
using Tree.Service.Shared;

namespace Tree.Service.Queries.Region.ListRegionDevicesHistoryByRegion
{
    public class ResponseListRegionDevicesHistoryByRegion : BaseResultController
    {
        public ResponseListRegionDevicesHistoryByRegion(
            IEnumerable<DeviceDTO> devices,
            HttpStatusCode statusCode) : base(statusCode)
        {
            Devices = devices;
        }
        public IEnumerable<DeviceDTO> Devices { get; private set; }
    }
}
