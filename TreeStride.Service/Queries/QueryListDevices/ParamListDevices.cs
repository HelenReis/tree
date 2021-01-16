using System;
using System.Collections.Generic;
using System.Text;
using TreeStride.Service.Base;

namespace TreeStride.Service.Queries.QueryListDevices
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
