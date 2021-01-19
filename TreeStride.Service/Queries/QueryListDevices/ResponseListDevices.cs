using System;
using System.Collections.Generic;
using System.Text;
using Tree.Domain.Models;
using Tree.Service.Base;

namespace Tree.Service.Queries.QueryListDevices
{
    public class ResponseListDevices : QueryResponse
    {
        public Device Device { get; set; }
    }
}
