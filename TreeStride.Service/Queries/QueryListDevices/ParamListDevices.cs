using System;
using System.Collections.Generic;
using System.Text;
using Tree.Service.Base;

namespace Tree.Service.Queries.QueryListDevices
{
    public class ParamListDevices : QueryParam
    {
        public ParamListDevices(int deviceId)
        {
            DeviceId = deviceId;
        }

        public int DeviceId { get; set; }
    }
}
