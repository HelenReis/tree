using System.Collections.Generic;
using System.Net;
using Tree.Service.Shared;

namespace Tree.Service.Queries.Region.ListRegions
{
    public class ResponseListRegions : BaseResultController
    {
        public ResponseListRegions(
            IEnumerable<Domain.Models.Region> regions,
            HttpStatusCode statusCode) : base(statusCode)
        {
            Regions = regions;
        }

        public IEnumerable<Domain.Models.Region> Regions { get; private set; }
    }
}
