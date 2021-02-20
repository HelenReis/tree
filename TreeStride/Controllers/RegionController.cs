using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using Tree.Controllers.Helpers;
using Tree.Service.Queries.Device.ListDevices;
using Tree.Service.Queries.Device.SelectDeviceById;
using Tree.Service.Queries.Region.ListAverageReadingsByDays;
using Tree.Service.Queries.Region.ListDevicesByRegion;
using Tree.Service.Queries.Region.ListRegionDevicesHistoryByRegion;
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
        public async virtual Task<IActionResult> GetRegions(
            [FromQuery(Name = Constantes.SKIP)] int skip,
            [FromQuery(Name = Constantes.LIMIT)] int limit)
        {
            try
            {
                var res = await _mediator.Send(new ParamListRegions(skip, limit));
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <remarks>select region by id</remarks>
        [HttpGet]
        [Route("{regionId:int}")]
        public async virtual Task<IActionResult> GetRegionById(int regionId)
        {
            try
            {
                var res = await _mediator.Send(new ParamSelectRegionById(regionId));
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <remarks>list devices by region by id</remarks>
        [HttpGet]
        [Route("{regionId:int}/devices")]
        public async virtual Task<IActionResult> GetDevicesByRegion(int regionId)
        {
            try
            {
                var res = await _mediator.Send(new ParamListDevicesByRegion(regionId));
                return Ok(res);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{regionId:int}/devices/history")]
        public async virtual Task<IActionResult> GetRegionDevicesHistory(int regionId)
        {
            try
            {
                var res = await _mediator.Send(new ParamListRegionDevicesHistoryByRegion(regionId));
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{regionId:int}/days/{days:int}/readings/average")]
        public async virtual Task<IActionResult> ListAverageReadingsByDays(int regionId, int days)
        {
            try
            {
                var res = await _mediator.Send(
                    new ParamListAverageReadingsByDays(regionId, days));

                return Ok(res);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
