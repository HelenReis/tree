using System.Collections.Generic;

namespace Tree.Service.Queries.Region.ListRegions
{
    public class ResponseListRegions
    {
        public IEnumerable<Domain.Models.Region> Regions { get; set; }
    }
}
