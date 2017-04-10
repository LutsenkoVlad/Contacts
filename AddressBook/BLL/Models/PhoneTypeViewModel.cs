using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.BLL.Models
{
    public class PhoneTypeViewModel
    {
        public int PhoneTypeId { get; set; }

        public string Name { get; set; }

        public PhoneTypeViewModel() { }

        public PhoneTypeViewModel(int PhoneTypeId, string Name)
        {
            this.PhoneTypeId = PhoneTypeId;
            this.Name = Name;
        }
    }
}
