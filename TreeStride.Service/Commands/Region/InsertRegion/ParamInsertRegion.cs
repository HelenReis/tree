using MediatR;

namespace Tree.Service.Commands.Region.InsertRegion
{
    public class ParamInsertRegion : IRequest<ResponseInsertRegion>
    {
        public ParamInsertRegion(Domain.Models.Region region) {
            Region = region;
        }

        public Domain.Models.Region Region { get; private set; }
    }
}
