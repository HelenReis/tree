﻿using System;
using System.Threading.Tasks;
using TreeStride.Service.Base;
using TreeStride.Service.Queries.Base;

namespace TreeStride.Service.Queries.QueryListDevices
{
    public class QueryListDevices : IQueryExecutor
    {
        public QueryListDevices() { }

        public Task<TResponse> ExecuteQuery<TParam, TResponse>(TParam param)
            where TParam : QueryParam
            where TResponse : QueryResponse
        {
            throw new NotImplementedException();
        }
    }
}
