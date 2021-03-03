using MediatR;

namespace Tree.Service.Commands.Device.InsertDevice
{
    public class ParamInsertDevice : IRequest<ResponseInsertDevice>
    {
        public ParamInsertDevice(Domain.Models.Device device) {
            Device = device;
        }

        public Domain.Models.Device Device { get; private set; }
    }
}
