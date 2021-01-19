using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tree.Service.Base;

namespace Tree.Service.Queries.Base.Emitter
{
    public interface IQueryEmitter
    {
        Task<TResponse> ExecuteQuery<TParam, TResponse>(TParam param)
            where TParam : QueryParam
            where TResponse : QueryResponse;
    }
}
