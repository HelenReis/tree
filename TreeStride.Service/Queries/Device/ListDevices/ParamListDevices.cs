using MediatR;

namespace Tree.Service.Queries.Device.ListDevices
{
    public class ParamListDevices : IRequest<ResponseListDevices>
    {
        public ParamListDevices() { }
    }
}
