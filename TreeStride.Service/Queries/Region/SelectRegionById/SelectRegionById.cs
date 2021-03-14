using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Tree.Data.Contract;
using Tree.Domain.DTOs;

namespace Tree.Service.Queries.Region.SelectRegionById
{
    public class SelectRegionById : IRequestHandler<ParamSelectRegionById, ResponseSelectRegionById>
    {
        private readonly IRegionRepository _regionRepository;

        public SelectRegionById(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public async Task<ResponseSelectRegionById> Handle(ParamSelectRegionById request, CancellationToken cancellationToken)
        {
            try
            {
                var region = await _regionRepository
                    .Query()
                    .Where(r => r.Id == request.RegionId)
                    .Select(r => new RegionDTO(r.Id, r.Latitude, r.Longitude, r.Description))
                    .FirstOrDefaultAsync();  

                return new ResponseSelectRegionById(region, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
