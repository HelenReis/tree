using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tree.Service.Queries.Device.QueryListDevices;

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

        /// <remarks>returns device by id</remarks>
        /// <param name="deviceId">deviceId</param>
        [HttpGet]
        [Route("{deviceId:int}")]
        public async virtual Task<IActionResult> GetDevices([FromRoute] int deviceId)
        {
            var res = await _mediator.Send(new ParamListDevices(deviceId));
            return Ok(res);
        }

        /// <remarks>gets the average sensor readings of the device in the standard of one week</remarks>
        /// <param name="deviceId"></param>
        /// <response code="200">response</response>
        [HttpGet]
        [Route("{deviceId:int}/readings/average")]
        public virtual IActionResult GetDeviceAverageSensorReading(int deviceId)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(DeviceAverageSensorReading));
            string exampleJson = null;
            exampleJson = "{\n  \"statusSafetyColor\" : \"green\",\n  \"averageHumidity\" : 1.4658129805029452,\n  \"averageTemperature\" : 6.027456183070403,\n  \"id\" : 0,\n  \"device\" : {\n    \"sensorReading\" : [ {\n      \"temperature\" : 2.3021358869347655,\n      \"humidity\" : 7.061401241503109,\n      \"id\" : 5\n    }, {\n      \"temperature\" : 2.3021358869347655,\n      \"humidity\" : 7.061401241503109,\n      \"id\" : 5\n    } ],\n    \"id\" : 0,\n    \"region\" : [ {\n      \"devices\" : [ null, null ],\n      \"lon\" : 5.962133916683182,\n      \"id\" : 6,\n      \"lat\" : 1.4658129805029452\n    }, {\n      \"devices\" : [ null, null ],\n      \"lon\" : 5.962133916683182,\n      \"id\" : 6,\n      \"lat\" : 1.4658129805029452\n    } ],\n    \"enabled\" : true\n  }\n}";

            return new ObjectResult(exampleJson);
        }
    }


}
