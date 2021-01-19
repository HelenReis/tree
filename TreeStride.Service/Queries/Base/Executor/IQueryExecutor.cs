using System.Threading.Tasks;
using Tree.Service.Base;

namespace Tree.Service.Queries.Base.Executor
{
    public interface IQueryExecutor<TParam, TResponse> 
        where TParam : QueryParam
        where TResponse : QueryResponse
    {
        Task<TResponse> ExecuteQuery(TParam param);
    }
}
