using Base.Model.Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Model.Common
{
    public class ResponseError<T> : IResponseError<T>
    {
        public string Message { get; set; }
        public T e { get; set; }
    }

}
