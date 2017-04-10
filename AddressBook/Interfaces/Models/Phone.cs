using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Interfaces.Models
{
    public class Phone
    {
        public int PhoneId { get; set; }

        public string Number { get; set; }

        public int PhoneTypeId { get; set; }

        public PhoneType Type { get; set; }

        public int ContactId { get; set; }

        public Contact contact { get; set; }
    }
}
