using System;
using System.Threading.Tasks;
using TreeStride.Data.Contract;
using TreeStride.Data.Repositories.Transaction.UnitOfWork;
using TreeStride.Domain.Models;
using TreeStride.Service.Base;
using TreeStride.Service.Queries.Base;

namespace TreeStride.Service.Queries.QueryListDevices
{
    public class QueryListDevices : IQueryExecutor<QueryParam, QueryResponse>
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IRegionRepository _regionRepository;
        private readonly IUnitOfWork _unitOfWork;
        public QueryListDevices(IDeviceRepository deviceRepository, IRegionRepository regionRepository, IUnitOfWork unitOfWork)
        {
            _deviceRepository = deviceRepository;
            _regionRepository = regionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TResponse> ExecuteQuery<TParam, TResponse>(TParam param)
            where TParam : QueryParam
            where TResponse : QueryResponse
        {

            try
            {
                var region = new Region(5, 5);
                _regionRepository.Create(region);
                await _unitOfWork.Commit();
                throw new NotImplementedException();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new NotImplementedException();
            }
        }
    }
}
