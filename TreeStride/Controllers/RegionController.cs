using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Net;
using System.Threading.Tasks;
using Tree.Controllers.Helpers;
using Tree.Domain.Models;
using Tree.Service.Commands.Region.InsertRegion;
using Tree.Service.Queries.Region.ListAverageReadingsByDays;
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

        [HttpGet]
        [SwaggerOperation(
            Summary = "Returns regions",
            OperationId = "GetRegions"
        )]
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

        [HttpGet]
        [SwaggerOperation(
            Summary = "Returns region by id",
            OperationId = "GetRegionById"
        )]
        [Route("{id:int}")]
        public async virtual Task<IActionResult> GetRegionById(int id)
        {
            try
            {
                var res = await _mediator.Send(new ParamSelectRegionById(id));
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Returns devices history by region",
            OperationId = "GetRegionDevicesHistory"
        )]
        [Route("{id:int}/devices/history")]
        public async virtual Task<IActionResult> GetRegionDevicesHistory(int id)
        {
            try
            {
                var res = await _mediator.Send(new ParamListRegionDevicesHistoryByRegion(id));
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Returns average sensor readings by days by region",
            OperationId = "ListAverageReadingsByDays"
        )]
        [Route("{id:int}/days/{days:int}/readings/average")]
        public async virtual Task<IActionResult> ListAverageReadingsByDays(int id, int days)
        {
            try
            {
                var res = await _mediator.Send(
                    new ParamListAverageReadingsByDays(id, days));

                return Ok(res);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Creates a new region",
            OperationId = "InsertRegion"
        )]
        [SwaggerResponse((int)HttpStatusCode.Created, "The region was created")]
        [Route("")]
        public async virtual Task<IActionResult> InsertRegion(
            Region region)
        {
            try
            {
                var res = await _mediator.Send(new ParamInsertRegion(region));
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
