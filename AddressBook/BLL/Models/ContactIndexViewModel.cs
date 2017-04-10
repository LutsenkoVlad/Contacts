using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.BLL.Models
{
    public class ContactIndexViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ContactIndexViewModel(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
