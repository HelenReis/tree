using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tree.Service.Queries.Device.ListDevices;
using Tree.Service.Queries.Device.SelectDeviceById;

namespace Tree.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DeviceController(
            IMediator mediator
            )
        {
            _mediator = mediator;
        }

        /// <remarks>returns all devices</remarks>
        [HttpGet]
        [Route("")]
        public async virtual Task<IActionResult> GetDevices()
        {
            var res = await _mediator.Send(new ParamListDevices());
            return Ok(res);
        }

        /// <remarks>select device by id</remarks>
        [HttpGet]
        [Route("{deviceId:int}")]
        public async virtual Task<IActionResult> GetDeviceById(int deviceId)
        {
            var res = await _mediator.Send(new ParamSelectDeviceById(deviceId));
            return Ok(res);
        }
    }
}
