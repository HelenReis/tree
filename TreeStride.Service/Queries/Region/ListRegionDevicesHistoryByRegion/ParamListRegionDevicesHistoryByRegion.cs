using MediatR;

namespace Tree.Service.Queries.Region.ListRegionDevicesHistoryByRegion
{
    public class ParamListRegionDevicesHistoryByRegion : IRequest<ResponseListRegionDevicesHistoryByRegion>
    {
        public ParamListRegionDevicesHistoryByRegion(int regionId) {
            RegionId = regionId;
        }

        public int RegionId { get; private set; }
    }
}
