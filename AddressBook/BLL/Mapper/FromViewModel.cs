using AddressBook.BLL.Models;
using AddressBook.Interfaces.Models;
using System.Collections.Generic;

namespace AddressBook.BLL.Mapper
{
    public class FromViewModel
    {
        private static IList<Phone> FromPhonesView(IList<PhoneViewModel> phones)
        {
            IList<Phone> Phones = new List<Phone>();
            foreach (var phone in phones)
            {
                //PhoneType type = FromPhoneTypeView(phone.Type);
                Phone _phone = new Phone
                {
                    PhoneId = phone.PhoneId,
                    Number = phone.Number,
                    PhoneTypeId = phone.PhoneTypeId,
                    Type = FromPhoneTypeView(phone.Type),
                    ContactId = phone.ContactId
                };
                Phones.Add(_phone);
            }
            return Phones;
        }

        private static PhoneType FromPhoneTypeView(PhoneTypeViewModel typeView)
        {
            PhoneType type = new PhoneType()
            {
                PhoneTypeId = typeView.PhoneTypeId,
                Name = typeView.Name
            };
            
            return type;
        }

        public static Contact FromContactView(ContactViewModel contactView)
        {
            Contact contact = new Contact();
            contact.ContactId = contactView.ContactId;
            contact.Email = contactView.Email;
            contact.Login = contactView.Login;
            contact.Password = contactView.Password;
            contact.FirstName = contactView.FirstName;
            contact.LastName = contactView.LastName;
            contact.Country = contactView.Country;
            contact.City = contactView.City;
            contact.Address = contactView.Address;
            contact.IsPrivateBirthDate = contactView.IsPrivateBirthDate;
            contact.BirthDate = contactView.BirthDate;
            if (contact.Phones != null)
            {
                contact.Phones = FromPhonesView(contactView.Phones);
                foreach (Phone phone in contact.Phones)
                {
                    phone.contact = contact;
                }
            }
            contact.ImageMimeType = contactView.ImageMimeType;
            contact.ImageData = contactView.ImageData;
            return contact;
        }
    }
}
