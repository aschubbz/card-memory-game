using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Model.Common
{
    public class ResponseWithDataModel<T>
    {
        public string Message { get; set; }
        public bool success { get; set; }
        public T Data { get; set; }
    }
}
