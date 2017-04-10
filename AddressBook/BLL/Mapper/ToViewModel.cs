using AddressBook.BLL.Models;
using AddressBook.Interfaces.Models;
using System.Collections.Generic;

namespace AddressBook.BLL.Mapper
{
    public class ToViewModel
    {
        private static IList<PhoneViewModel> ToPhonesViewModel(IEnumerable<Phone> phones)
        {
            IList<PhoneViewModel> Phones = new List<PhoneViewModel>();
            foreach (var phone in phones)
            {
                PhoneViewModel _phone = new PhoneViewModel(phone.PhoneId,phone.ContactId,phone.PhoneTypeId, phone.Number, ToPhoneTypeViewModel(phone.Type));
                Phones.Add(_phone);
            }
            return Phones;
        }

        private static PhoneTypeViewModel ToPhoneTypeViewModel(PhoneType type)
        {
            var typeView = new PhoneTypeViewModel(type.PhoneTypeId, type.Name);
            return typeView;
        }

        public static ContactViewModel ToContactViewModel(Contact contact)
        {
            var contactView = new ContactViewModel(contact.ContactId,contact.Login,contact.Password, contact.FirstName,contact.LastName,contact.Country,
                                                   contact.City,contact.Email,contact.Address,contact.IsPrivateBirthDate,contact.BirthDate,
                                                   ToPhonesViewModel(contact.Phones),contact.ImageMimeType,contact.ImageData);

            return contactView;
        }

        //public static UserViewModel ToUserViewModel(User user)
        //{
        //    UserViewModel userView = new UserViewModel(user.Id,user.Email,user.Login,user.Password,
        //                                               user.FirstName,user.LastName,user.Gender);

        //    if(user.BirthDate != null)
        //    {
        //        userView.BirthDate = user.BirthDate;
        //    }

        //    if(user.Image != null)
        //    {
        //        userView.Image = user.Image;
        //    }

        //    return userView; 
        //}
    }
}
