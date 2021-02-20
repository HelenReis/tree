using System;
using System.Collections.Generic;
using System.Text;

namespace Tree.Service.Queries.Region.ListDevicesByRegion
{
    class ResponseListDevicesByRegion
    {
        public IEnumerable<Domain.Models.Device> Devices { get;  set; }
    }
}
