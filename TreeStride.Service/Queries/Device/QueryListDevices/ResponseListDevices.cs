using System;
using System.Collections.Generic;
using System.Text;
using Tree.Domain.Models;
using Tree.Service.Base;

namespace Tree.Service.Queries.Device.QueryListDevices
{
    public class ResponseListDevices
    {
        public Domain.Models.Device Device { get; set; }
    }
}
