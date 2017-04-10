using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.BLL.Models
{
    public class PagingContactsIndexViewModel
    {
        public IEnumerable<ContactIndexViewModel> Contacts { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}
