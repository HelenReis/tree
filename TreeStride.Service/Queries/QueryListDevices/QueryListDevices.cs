using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TreeStride.Service.Base;
using TreeStride.Service.Contract;

namespace TreeStride.Service.Queries.QueryListDevices
{
    public class QueryListDevices : IQueryService<ParamListDevices, ResponseListDevices>
    {
        public Task<QueryResponse> Query(ParamListDevices param)
        {
            throw new NotImplementedException();

        }
    }
}
