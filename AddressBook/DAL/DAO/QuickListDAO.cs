using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using AddressBook.Interfaces.IDAL;
using AddressBook.Interfaces.Models;
using DAL.Context;
using System;

namespace DAL.DAO
{
    public class QuickListDAO : IQuickListDAO
    {
        public bool AddToQuickList(int contactId, int quickListId)
        {
            using (var db = new ContactsContext())
            {
                Contact contact = db.Contacts.Find(contactId);
                QuickList quickList = db.QuickLists.Find(quickListId);
                if (contact != null && quickList != null)
                {
                    quickList.Contacts.Add(contact);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool CreateQuickList(QuickList quickList)
        {
            using (ContactsContext db = new ContactsContext())
            {
                db.QuickLists.Add(quickList);
                db.SaveChanges();
            }
            return true;
        }

        public IList<QuickList> GetAll(string login)
        {
            using (var db = new ContactsContext())
            {
                int contactId = db.Contacts.Where(c => c.Login == login).Single().ContactId;
                var list = db.QuickLists.Where(c => c.ContactId == contactId).Include(c => c.Contacts).ToList();
                return list;
            }
        }

        public IEnumerable<QuickList> GetQuickLists(int contactId)
        {
            using (var db = new ContactsContext())
            {
                var list = db.QuickLists.Where(q => q.ContactId == contactId).ToList();
                return list;
            }
        }

        public bool CreateQuickList(int personId)
        {
            using (var context = new ContactsContext())
            {
                QuickList list = new QuickList() { ContactId = personId, Name = "Favorite" };
                context.QuickLists.Add(list);
                context.SaveChanges();
            }
            return true;
        }
    }
}
