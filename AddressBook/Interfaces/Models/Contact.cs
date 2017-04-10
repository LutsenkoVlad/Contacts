using System;
using System.Collections.Generic;

namespace AddressBook.Interfaces.Models
{
    public class Contact
    {
        public int ContactId { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public bool IsPrivateBirthDate { get; set; }

        public DateTime? BirthDate { get; set; }

        public bool IsPrivatePhoto { get; set; }

        public byte[] ImageData { get; set; }

        public string ImageMimeType { get; set; }

        public virtual IList<Phone> Phones { get; set; }

        public virtual IList<QuickList> QuickLists { get; set; }

        public Contact()
        {
            Phones = new List<Phone>();
            QuickLists = new List<QuickList>();
        }
    }
}
