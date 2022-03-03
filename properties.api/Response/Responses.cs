using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace properties.api.Response
{
    public class Responses<T>
    {

        public Responses(T data) {
            Data = data;
        }

        public T Data { get; set; }
    }
}
