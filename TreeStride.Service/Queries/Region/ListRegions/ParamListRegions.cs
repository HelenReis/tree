using MediatR;

namespace Tree.Service.Queries.Region.ListRegions
{
    public class ParamListRegions : IRequest<ResponseListRegions>
    {
        public ParamListRegions(int skip, int limit) {
            Skip = skip;
            Limit = limit;
        }

        public int Skip { get; private set; }

        public int Limit { get; private set; }
    }
}
