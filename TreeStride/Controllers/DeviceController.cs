using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using Tree.Controllers.Helpers;
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
        public async virtual Task<IActionResult> GetDevices(
            [FromQuery(Name = Constantes.SKIP)] int skip,
            [FromQuery(Name = Constantes.LIMIT)] int limit)
        {
            try
            {
                var res = await _mediator.Send(new ParamListDevices(skip, limit));
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <remarks>select device by id</remarks>
        [HttpGet]
        [Route("{deviceId:int}")]
        public async virtual Task<IActionResult> GetDeviceById(int deviceId)
        {
            try
            {
                var res = await _mediator.Send(new ParamSelectDeviceById(deviceId));
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
