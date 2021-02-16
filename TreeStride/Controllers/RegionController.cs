using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tree.Service.Queries.Device.ListDevices;
using Tree.Service.Queries.Device.SelectDeviceById;
using Tree.Service.Queries.Region.ListRegions;
using Tree.Service.Queries.Region.SelectRegionById;

namespace Tree.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RegionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <remarks>returns all regions</remarks>
        [HttpGet]
        [Route("")]
        public async virtual Task<IActionResult> GetRegions()
        {
            var res = await _mediator.Send(new ParamListRegions());
            return Ok(res);
        }

        /// <remarks>select region by id</remarks>
        [HttpGet]
        [Route("{regionId:int}")]
        public async virtual Task<IActionResult> GetRegionById(int regionId)
        {
            var res = await _mediator.Send(new ParamSelectRegionById(regionId));
            return Ok(res);
        }

        /// <remarks>list devices by region by id</remarks>
        [HttpGet]
        [Route("{regionId:int}/devices")]
        public async virtual Task<IActionResult> GetDevicesByRegion(int regionId)
        {
            var res = await _mediator.Send(new ParamSelectRegionById(regionId));
            return Ok(res);
        }
    }
}
