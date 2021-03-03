using System.Collections.Generic;
using System.Net;
using Tree.Service.Shared;

namespace Tree.Service.Queries.Region.SelectRegionById
{
    public class ResponseSelectRegionById : BaseResultController
    {
        public ResponseSelectRegionById(
            Domain.Models.Region region,
            HttpStatusCode statusCode) : base(statusCode)
        {
            Region = region;
        }

        public Domain.Models.Region Region { get; set; }
    }
}
