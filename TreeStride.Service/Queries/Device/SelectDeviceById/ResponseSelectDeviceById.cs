using System.Collections.Generic;

namespace Tree.Service.Queries.Device.SelectDeviceById
{
    public class ResponseSelectDeviceById
    {
        public IEnumerable<Domain.Models.Device> Devices { get; set; }
    }
}
