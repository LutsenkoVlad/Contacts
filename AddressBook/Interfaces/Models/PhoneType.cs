using System.Collections.Generic;

namespace AddressBook.Interfaces.Models
{
    public class PhoneType
    {
        public int PhoneTypeId { get; set; }

        public string Name { get; set; }

        public virtual IList<Phone> Phones { get; set; }

        public PhoneType()
        {
            Phones = new List<Phone>();
        }
    }

}
