using System.Collections.Generic;
using System.Net;
using Tree.Domain.DTOs;
using Tree.Service.Shared;

namespace Tree.Service.Queries.Region.ListRegions
{
    public class ResponseListRegions : BaseResultController
    {
        public ResponseListRegions(
            IEnumerable<RegionDTO> regions,
            HttpStatusCode statusCode) : base(statusCode)
        {
            Regions = regions;
        }

        public IEnumerable<RegionDTO> Regions { get; private set; }
    }
}
