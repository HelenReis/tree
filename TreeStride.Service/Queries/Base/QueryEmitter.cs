﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TreeStride.Service.Base;

namespace TreeStride.Service.Queries.Base
{
    public class QueryEmitter : IQueryEmitter
    {
        public Task<TResponse> ExecuteQuery<TParam, TResponse>(TParam param)
            where TParam : QueryParam
            where TResponse : QueryResponse
        {
            throw new NotImplementedException();
        }
    }
}