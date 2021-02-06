using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SM.Api.Response
{
    public class ApiResponse<T>
    {
        public ApiResponse(T t)
        {
            Data = t;

        }
        public T Data { get; set; }
    }
}
