using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TreeStride.Service.Base;
using TreeStride.Service.Queries.Base.Executor;

namespace TreeStride.Service.Queries.Base.Emitter
{
    public class QueryEmitter : IQueryEmitter
    {
        public async Task<TResponse> ExecuteQuery<TParam, TResponse>(TParam param)
            where TParam : QueryParam
            where TResponse : QueryResponse
        {
            var executor = new QueryExecutor<TParam, TResponse>();
            return await executor.ExecuteQuery(param);
        }
    }
}
