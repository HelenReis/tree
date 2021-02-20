using MediatR;

namespace Tree.Service.Queries.Device.ListDevices
{
    public class ParamListDevices : IRequest<ResponseListDevices>
    {
        public ParamListDevices(int skip, int limit)
        {
            Skip = skip;
            Limit = limit;
        }

        public int Skip { get; private set; }

        public int Limit { get; private set; }
    }
}
