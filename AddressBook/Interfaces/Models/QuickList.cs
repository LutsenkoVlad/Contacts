using System.Collections.Generic;

namespace AddressBook.Interfaces.Models
{
    public class QuickList
    {
        public int QuickListId { get; set; }

        public string Name { get; set; }

        public int ContactId { get; set; }

        public virtual IList<Contact> Contacts { get; set; }

        public QuickList()
        {
            Contacts = new List<Contact>();
        }
    }
}
