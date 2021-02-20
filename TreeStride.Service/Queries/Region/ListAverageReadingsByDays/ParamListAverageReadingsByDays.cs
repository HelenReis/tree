using MediatR;

namespace Tree.Service.Queries.Region.ListAverageReadingsByDays
{
    public class ParamListAverageReadingsByDays : IRequest<ResponseListAverageReadingsByDays>
    {
        public ParamListAverageReadingsByDays(int regionId, int days) {
            RegionId = regionId;
            Days = days;
        }

        public int RegionId { get; private set; }

        public int Days { get; private set; }
    }
}
