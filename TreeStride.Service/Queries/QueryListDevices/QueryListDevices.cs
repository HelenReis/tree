using System;
using System.Threading.Tasks;
using Tree.Data.Contract;
using Tree.Service.Queries.Base;
using Tree.Service.Queries.Base.Executor;

namespace Tree.Service.Queries.QueryListDevices
{
    public class QueryListDevices : QueryExecutor<ParamListDevices, ResponseListDevices>
    {
        private readonly IDeviceRepository _deviceRepository;
        public QueryListDevices(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async override Task<ResponseListDevices> ExecuteQuery(ParamListDevices param)
        {
            try
            {
                var device = await _deviceRepository
                    .GetById(param.DeviceId);

                return new ResponseListDevices
                {
                    Device = device
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        /*public async Task<ResponseListDevices> ExecuteQuery(ParamListDevices param)
        {
            try
            {
                var device = await _deviceRepository
                    .GetById(param.DeviceId);

                return new ResponseListDevices
                {
                    Device = device
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }*/
    }
}
