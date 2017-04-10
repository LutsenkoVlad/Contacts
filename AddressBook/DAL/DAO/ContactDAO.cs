using System.Collections.Generic;
using System.Data.Entity;
using AddressBook.Interfaces.IDAL;
using AddressBook.Interfaces.Models;
using DAL.Context;
using System.Linq;
using System;

namespace DAL.DAO
{
    public class ContactDAO : IContactDAO
    {
        public bool AddContact(Contact contact)
        {
            if (CheckLogin(contact.Login, contact.Email))
            {
                using (var db = new ContactsContext())
                {
                    db.Contacts.Add(contact);
                    db.SaveChanges();
                    return true;
                }
            }
            else
                return false;
        }

        public bool DeleteContact(int id)
        {
            using (var db = new ContactsContext())
            {
                Contact contact;
                contact = db.Contacts.Find(id);
                db.Contacts.Remove(contact);
                db.SaveChanges();
                return true;
            }
        }

        public bool EditContact(Contact contact)
        {
            //if(contact.Phones != null)
            //{
            //    foreach (var phone in contact.Phones)
            //        EditPhone(phone);
            //}
            using (var db = new ContactsContext())
            {
                db.Contacts.Attach(contact);
                db.Entry(contact).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;

            }
        }

        public Contact GetContact(int id)
        {
            Contact contact;
            using (var db = new ContactsContext())
            {
                contact = db.Contacts.Include(m => m.Phones.Select(p => p.Type)).SingleOrDefault(m => m.ContactId == id);
                return contact;

            }
        }

        public IEnumerable<Contact> GetAll()
        {
            using (var db = new ContactsContext())
            {
                IEnumerable<Contact> contactList;
                contactList = db.Contacts.ToList();
                return contactList;
            }

        }

        public bool AddPhone(Phone phone)
        {
            using (var db = new ContactsContext())
            {
                Phone _phone = phone;
                db.Phones.Add(_phone);
                db.SaveChanges();
                return true;

            }
        }

        public bool DeletePhone(int PhoneId)
        {
            using (var db = new ContactsContext())
            {
                Phone phone;
                phone = db.Phones.Find(PhoneId);
                db.Phones.Remove(phone);
                db.SaveChanges();
                return true;

            }
        }

        public IEnumerable<PhoneType> GetPhoneTypes()
        {
            var db = new ContactsContext();
         
                IEnumerable<PhoneType> type = db.PhoneTypes.ToList();
                return type;
        }

        public bool EditPhone(Phone phone)
        {
            Phone _phone = new Phone();
            _phone.ContactId = phone.ContactId;
            _phone.Number = phone.Number;
            _phone.PhoneTypeId = phone.PhoneTypeId;
            _phone.Type = phone.Type;
            using (var db = new ContactsContext())
            {
                db.Phones.Attach(phone);
                db.Phones.Remove(phone);
                
                db.SaveChanges();
            }

            using (var db = new ContactsContext())
            {
                db.Phones.Add(_phone);
                db.SaveChanges();
                db.Entry(_phone).State = EntityState.Modified;
                db.SaveChanges();
                return true;

            }
        }

        public Phone GetPhone(int Id)
        {
            using (var db = new ContactsContext())
            {
                Phone phone = db.Phones.Include(p => p.Type).SingleOrDefault(p => p.PhoneId == Id);
                return phone;
            }
        }

        public bool CheckLogin(string login = "", string email = "")
        {
            using (var db = new ContactsContext())
            {
                Contact contact = db.Contacts.Where(m => m.Login.Equals(login) || m.Email.Equals(email)).FirstOrDefault();
                if (contact == null)
                    return true;
                else
                    return false;
            }
        }

        public bool Authorize(string Login, string Password)
        {
            using (var db = new ContactsContext())
            {
                Contact contact = db.Contacts.Where(m => (m.Login.Equals(Login) || m.Email.Equals(Login)) && m.Password.Equals(Password)).FirstOrDefault();
                if (contact != null)
                    return true;
                else
                    return false;
            }
        }

        public Contact FindContactByLogin(string login)
        {
            using (var db = new ContactsContext())
            {
                Contact contact = db.Contacts.Include(c => c.Phones.Select(p => p.Type)).FirstOrDefault(m => (m.Login.Equals(login) || m.Email.Equals(login)));
                return contact;
            }
        }
    }
}
