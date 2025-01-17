﻿using MediatR;

namespace Tree.Service.Queries.Device.ListDevicesByRegion
{
    public class ParamListDevicesByRegion : IRequest<ResponseListDevicesByRegion>
    {
        public ParamListDevicesByRegion(int regionId)
        {
            RegionId = regionId;
        }

        public int RegionId { get; private set; }
    }
}
