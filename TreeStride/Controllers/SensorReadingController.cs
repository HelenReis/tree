using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Net;
using System.Threading.Tasks;
using Tree.Domain.Models;
using Tree.Service.Commands.SensorReading.InsertSensorReading;

namespace Tree.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensorReadingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SensorReadingController(
            IMediator mediator
            )
        {
            _mediator = mediator;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Creates a new sensor reading",
            OperationId = "InsertSensorReading"
        )]
        [SwaggerResponse((int)HttpStatusCode.Created, "The reading was created")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [Route("")]
        public async virtual Task<IActionResult> InsertSensorReading(
            SensorReading reading)
        {
            try
            {
                var res = await _mediator.Send(new ParamInsertSensorReading(reading));
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
