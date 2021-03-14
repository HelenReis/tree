using System.Collections.Generic;
using System.Net;
using Tree.Domain.DTOs;
using Tree.Service.Shared;

namespace Tree.Service.Queries.Region.SelectRegionById
{
    public class ResponseSelectRegionById : BaseResultController
    {
        public ResponseSelectRegionById(
            RegionDTO region,
            HttpStatusCode statusCode) : base(statusCode)
        {
            Region = region;
        }

        public RegionDTO Region { get; private set; }
    }
}
