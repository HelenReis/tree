using System;
using System.Threading.Tasks;
using TreeStride.Service.Base;

namespace TreeStride.Service.Queries.Base
{
    public class QueryExecutor : IQueryExecutor
    {
        public Task<TResponse> ExecuteQuery<TParam, TResponse>(TParam param)
            where TParam : QueryParam
            where TResponse : QueryResponse
        {
            throw new NotImplementedException();
        }
    }
}