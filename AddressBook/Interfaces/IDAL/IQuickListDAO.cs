using AddressBook.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Interfaces.IDAL
{
    public interface IQuickListDAO
    {
        bool AddToQuickList(int contactId,int quickListId);

        bool CreateQuickList(QuickList quickList);

        IList<QuickList> GetAll(string login);

        IEnumerable<QuickList> GetQuickLists(int contactId);
    }
}
