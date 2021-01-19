using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tree.Service.Base;
using Tree.Service.Queries.Base.Executor;

namespace Tree.Service.Queries.Base.Emitter
{
    public class QueryEmitter : IQueryEmitter
    {
        public QueryEmitter()
        {

        }

        public async Task<TResponse> ExecuteQuery<TParam, TResponse>(TParam param)
            where TParam : QueryParam
            where TResponse : QueryResponse
        {
            var executor = new QueryExecutor<TParam, TResponse>();
            return await executor.ExecuteQuery(param);
        }
    }
}
