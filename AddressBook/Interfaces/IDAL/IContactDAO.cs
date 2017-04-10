using System.Collections.Generic;
using AddressBook.Interfaces.Models;

namespace AddressBook.Interfaces.IDAL
{
    public interface IContactDAO
    {
        bool AddContact(Contact contact);

        bool DeleteContact(int id);

        bool EditContact(Contact contact);

        Contact GetContact(int id);

        IEnumerable<Contact> GetAll();

        bool AddPhone(Phone phone);

        bool DeletePhone(int PhoneId);

        IEnumerable<PhoneType> GetPhoneTypes();

        bool EditPhone(Phone phone);

        Phone GetPhone(int id);

        bool Authorize(string Login, string Password);

        Contact FindContactByLogin(string login);
    }
}
