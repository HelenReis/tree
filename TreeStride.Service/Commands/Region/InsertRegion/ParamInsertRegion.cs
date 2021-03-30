using MediatR;
using Newtonsoft.Json;
using Tree.Domain.DTOs;

namespace Tree.Service.Commands.Region.InsertRegion
{
    public class ParamInsertRegion : IRequest<ResponseInsertRegion>
    {
        public ParamInsertRegion(InsertRegionDTO region) {
            Region = region;
        }

        public InsertRegionDTO Region { get; private set; }
    }
}
