﻿using System.Threading.Tasks;
using TreeStride.Service.Base;

namespace TreeStride.Service.Queries.Base
{
    public interface IQueryExecutor<in TParametro, TResultado> where TParametro : QueryParam
    {
        Task<TResponse> ExecuteQuery<TParam, TResponse>(TParam param)
            where TParam : QueryParam
            where TResponse : QueryResponse;
    }
}