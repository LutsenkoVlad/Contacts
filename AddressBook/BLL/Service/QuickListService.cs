using AddressBook.Interfaces.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using AddressBook.BLL.Result;
using AddressBook.Interfaces.Models;

namespace AddressBook.BLL.Service
{
    public class QuickListService
    {
        public static IQuickListDAO _quickListService = Unity.Container.Resolve<IQuickListDAO>();

        public OneResult<QuickList> Create(QuickList quickList)
        {
            OneResult<QuickList> resultQuickList = new OneResult<QuickList>();
            try
            {
                if (_quickListService.CreateQuickList(quickList))
                    resultQuickList.Success = true;
                else
                {
                    resultQuickList.Success = false;
                    resultQuickList.Message = "Something was wrong with quicklist creating";
                }
            }
            catch(Exception ex)
            {
                resultQuickList.Success = false;
                resultQuickList.Message = ex.Message + " " + ex.StackTrace;
            }
            return resultQuickList; 
        }

        public ManyResults<QuickList> GetAll(string login)
        {
            ManyResults<QuickList> resultQuickList = new ManyResults<QuickList>();
            try
            {
                resultQuickList.List = _quickListService.GetAll(login);
                resultQuickList.Success = true;
            }
            catch(Exception ex)
            {
                resultQuickList.Success = false;
                resultQuickList.Message = ex.Message + " " + ex.StackTrace;
            }
            return resultQuickList; 
        }

        public OneResult<QuickList> AddContactToQuickList(int contactId, int quickListId)
        {
            OneResult<QuickList> result = new OneResult<QuickList>();
            try
            {
                if (_quickListService.AddToQuickList(contactId, quickListId))
                {
                    result.Success = true;
                    result.Message = "Contact has succesfully added";
                }
                else
                {
                    result.Success = false;
                    result.Message = "Contact has not successfully added";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
            }
            return result;
        }

        public ManyResults<QuickList> GetQuickLists(int contactId)
        {
            ManyResults<QuickList> resultContact = new ManyResults<QuickList>();
            try
            {
                resultContact.List = _quickListService.GetQuickLists(contactId);
                resultContact.Success = true;
            }
            catch (Exception ex)
            {
                resultContact.Success = false;
            }
            return resultContact;
        }
    }
}
