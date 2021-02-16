using MediatR;

namespace Tree.Service.Queries.Region.ListRegions
{
    public class ParamListRegions : IRequest<ResponseListRegions>
    {
        public ParamListRegions() { }
    }
}
