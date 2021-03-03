using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tree.Data.Contract;
using System.Linq;
using System.Net;

namespace Tree.Service.Queries.Region.ListRegions
{
    public class ListRegions : IRequestHandler<ParamListRegions, ResponseListRegions>
    {
        private readonly IRegionRepository _regionRepository;

        public ListRegions(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public async Task<ResponseListRegions> Handle(ParamListRegions request, CancellationToken cancellationToken)
        {
            try
            {
                var regions = await _regionRepository
                    .Query()
                    .Take(request.Limit)
                    .Skip(request.Skip)
                    .ToListAsync();

                return new ResponseListRegions(regions, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
