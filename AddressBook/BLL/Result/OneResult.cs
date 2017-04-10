using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.BLL.Result
{
    public class OneResult<T> : Result
    {
        public T Ob { get; set; }
    }
}
