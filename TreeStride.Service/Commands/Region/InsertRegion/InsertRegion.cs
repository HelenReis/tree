using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Tree.Data.Contract;
using Tree.Data.Repositories.Transaction.UnitOfWork;

namespace Tree.Service.Commands.Region.InsertRegion
{
    public class InsertRegion : IRequestHandler<ParamInsertRegion, ResponseInsertRegion>
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InsertRegion(IRegionRepository regionRepository, IUnitOfWork unitOfWork)
        {
            _regionRepository = regionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseInsertRegion> Handle(ParamInsertRegion request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.Region.IsValid)
                    return new ResponseInsertRegion(
                        HttpStatusCode.BadRequest,
                        request.Region.Notifications);

                _regionRepository.Create(
                    new Domain.Models.Region(
                        latitude: request.Region.Latitude,
                        longitude: request.Region.Longitude,
                        description: request.Region.Description));

                await _unitOfWork.Commit();

                return new ResponseInsertRegion(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
