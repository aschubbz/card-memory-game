using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Model.Common.Abstract
{
    public interface IResponseError<T>
    {
        string Message { get; set; }
        T e { get; set; }
    }
}
