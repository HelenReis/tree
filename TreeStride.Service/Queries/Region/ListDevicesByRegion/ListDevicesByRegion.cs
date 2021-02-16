using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tree.Service.Queries.Region.ListDevicesByRegion
{
    class ListDevicesByRegion : IRequestHandler<ParamListDevicesByRegion, ResponseListDevicesByRegion>
    {
        public Task<ResponseListDevicesByRegion> Handle(ParamListDevicesByRegion request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
