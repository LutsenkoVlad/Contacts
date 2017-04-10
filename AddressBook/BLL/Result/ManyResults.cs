using System.Collections.Generic;

namespace AddressBook.BLL.Result
{
    public class ManyResults<T> : Result
    {
        public IEnumerable<T> List { get; set; }
    }
}
