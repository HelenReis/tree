﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tree.Service.Base;

namespace Tree.Service.Queries.Base.Executor
{
    public class QueryExecutor<TParam, TResponse> : IQueryExecutor<TParam, TResponse>
        where TParam : QueryParam
        where TResponse : QueryResponse
    {
        public virtual Task<TResponse> ExecuteQuery(TParam param)
        {
            throw new NotImplementedException();
        }
    }
}