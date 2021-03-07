using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Net;
using System.Threading.Tasks;
using Tree.Controllers.Helpers;
using Tree.Domain.Models;
using Tree.Service.Commands.Device.InsertDevice;
using Tree.Service.Queries.Device.ListDevices;
using Tree.Service.Queries.Device.ListDevicesByRegion;
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

        [HttpGet]
        [SwaggerOperation(
            Summary = "Returns devices",
            OperationId = "GetDevices"
        )]
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

        [HttpGet]
        [SwaggerOperation(
            Summary = "Returns device by id",
            OperationId = "GetDeviceById"
        )]
        [Route("{id:int}")]
        public async virtual Task<IActionResult> GetDeviceById(int id)
        {
            try
            {
                var res = await _mediator.Send(new ParamSelectDeviceById(id));
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Returns devices by region",
            OperationId = "GetDevicesByRegion"
        )]
        [Route("{id:int}/devices")]
        public async virtual Task<IActionResult> GetDevicesByRegion(int id)
        {
            try
            {
                var res = await _mediator.Send(new ParamListDevicesByRegion(id));
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Creates a new device",
            OperationId = "InsertDevice"
        )]
        [SwaggerResponse((int)HttpStatusCode.Created, "The device was created")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [Route("")]
        public async virtual Task<IActionResult> InsertDevice(
            Device device)
        {
            try
            {
                var res = await _mediator.Send(new ParamInsertDevice(device));
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
