using System.Collections.Generic;

namespace Tree.Service.Queries.Region.ListRegionDevicesHistoryByRegion
{
    public class ResponseListRegionDevicesHistoryByRegion
    {
        public ResponseListRegionDevicesHistoryByRegion(
            IEnumerable<Domain.Models.Device> devices)
        {
            Devices = devices;
        }
        public IEnumerable<Domain.Models.Device> Devices { get; private set; }
    }
}
