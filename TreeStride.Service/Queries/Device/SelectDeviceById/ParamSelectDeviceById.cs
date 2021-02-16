using MediatR;

namespace Tree.Service.Queries.Device.SelectDeviceById
{
    public class ParamSelectDeviceById : IRequest<ResponseSelectDeviceById>
    {
        public ParamSelectDeviceById(int deviceId) {
            DeviceId = deviceId;
        }

        public int DeviceId { get; private set; }
    }
}
