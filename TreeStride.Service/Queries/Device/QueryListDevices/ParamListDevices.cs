using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tree.Service.Base;

namespace Tree.Service.Queries.Device.QueryListDevices
{
    public class ParamListDevices : IRequest<ResponseListDevices>
    {
        public ParamListDevices(int deviceId)
        {
            DeviceId = deviceId;
        }

        public int DeviceId { get; set; }
    }
}
