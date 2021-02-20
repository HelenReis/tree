using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tree.Data.Contract;

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
                    .GetById(request.RegionId);

                return new ResponseSelectRegionById { Region = region };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
