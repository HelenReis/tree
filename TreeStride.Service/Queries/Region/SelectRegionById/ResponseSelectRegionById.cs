using System.Collections.Generic;

namespace Tree.Service.Queries.Region.SelectRegionById
{
    public class ResponseSelectRegionById
    {
        public IEnumerable<Domain.Models.Region> Regions { get; set; }
    }
}
