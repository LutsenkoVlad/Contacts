using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.BLL.Models
{
    public class PhoneViewModel
    {

        public int PhoneId { get; set; }

        public string Number { get; set; }

        public int PhoneTypeId { get; set; }

        public PhoneTypeViewModel Type { get; set; }

        public int ContactId { get; set; }

        public PhoneViewModel() { }

        public PhoneViewModel(int PhoneId,int ContactId,int PhonetypeId, string Number, PhoneTypeViewModel Type)
        {
            this.PhoneId = PhoneId;
            this.ContactId = ContactId;
            this.PhoneTypeId = Type.PhoneTypeId;
            this.Number = Number;
            this.Type = new PhoneTypeViewModel(Type.PhoneTypeId, Type.Name);
        }
    }
}
