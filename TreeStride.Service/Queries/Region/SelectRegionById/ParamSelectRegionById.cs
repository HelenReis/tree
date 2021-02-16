using MediatR;

namespace Tree.Service.Queries.Region.SelectRegionById
{
    public class ParamSelectRegionById : IRequest<ResponseSelectRegionById>
    {
        public ParamSelectRegionById(int regionId) {
            RegionId = regionId;
        }

        public int RegionId { get; private set; }
    }
}
