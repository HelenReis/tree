using System.Collections.Generic;

namespace Tree.Service.Queries.Device.QueryListDevices
{
    public class ResponseListDevices
    {
        public IEnumerable<Domain.Models.Device> Devices { get; set; }
    }
}
