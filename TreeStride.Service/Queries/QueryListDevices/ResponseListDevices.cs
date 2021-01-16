using System;
using System.Collections.Generic;
using System.Text;
using TreeStride.Domain.Models;
using TreeStride.Service.Base;

namespace TreeStride.Service.Queries.QueryListDevices
{
    public class ResponseListDevices : QueryResponse
    {
        public IEnumerable<Device> Devices { get; set; }
    }
}
