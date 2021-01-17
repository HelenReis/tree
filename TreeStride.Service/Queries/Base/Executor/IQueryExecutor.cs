using System.Threading.Tasks;
using TreeStride.Service.Base;

namespace TreeStride.Service.Queries.Base.Executor
{
    public interface IQueryExecutor<TParam, TResponse> 
        where TParam : QueryParam
        where TResponse : QueryResponse
    {
        Task<TResponse> ExecuteQuery(TParam param);
    }
}
