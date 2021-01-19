using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tree.Service.Base;

namespace Tree.Service.Contract
{
    public interface IQueryService<TParam, TResponse> 
        where TParam : QueryParam
        where TResponse : QueryResponse
    {
        Task<QueryResponse> Query(TParam param);
    }
}
