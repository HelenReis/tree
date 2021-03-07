using MediatR;
using Tree.Domain.DTOs;

namespace Tree.Service.Commands.Device.InsertDevice
{
    public class ParamInsertDevice : IRequest<ResponseInsertDevice>
    {
        public ParamInsertDevice(InsertDeviceDTO device) {
            Device = device;
        }

        public InsertDeviceDTO Device { get; private set; }
    }
}
