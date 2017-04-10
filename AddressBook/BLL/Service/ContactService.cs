using AddressBook.BLL.Result;
using AddressBook.Interfaces.IDAL;
using System;
using AddressBook.Interfaces.Models;
using AddressBook.BLL.Mapper;
using AddressBook.BLL.Models;
using System.Collections.Generic;
using Microsoft.Practices.Unity;

namespace AddressBook.BLL.Service
{
    public class ContactService
    {
        public static IContactDAO _contactService = Unity.Container.Resolve<IContactDAO>();

        public ContactService() { }

        public OneResult<ContactViewModel> Create(ContactViewModel contactView)
        {
            OneResult<ContactViewModel> resultContact = new OneResult<ContactViewModel>();
            try
            {
                Contact contact = FromViewModel.FromContactView(contactView);
                if (_contactService.AddContact(contact))
                {
                    resultContact.Success = true;
                    resultContact.Message = "Register was successful";
                }
                else
                {
                    resultContact.Success = false;
                    resultContact.Message = "Register has failed";
                }
            }
            catch (Exception ex)
            {
                //TODO log
                resultContact.Success = false; 
            }
            return resultContact;
        }

        public OneResult<ContactViewModel> EditContact(ContactViewModel contactModel)
        {
            OneResult<ContactViewModel> resultContact = new OneResult<ContactViewModel>();
            try
            {
                Contact contact = FromViewModel.FromContactView(contactModel);

                if (_contactService.EditContact(contact))
                {
                    resultContact.Success = true;
                }
                else
                {
                    resultContact.Success = false;
                    resultContact.Message = "Information does not change";
                }
            }
            catch (Exception ex)
            {
                //TODO log
                resultContact.Success = false;
            }
            return resultContact; 
        }

        public OneResult<ContactViewModel> Get(int id)
        {
            OneResult<ContactViewModel> resultContact = new OneResult<ContactViewModel>();
            try
            {
                ContactViewModel contactView = ToViewModel.ToContactViewModel(_contactService.GetContact(id));
                resultContact.Ob = contactView;
                resultContact.Success = true;
            }
            catch (Exception ex)
            {
                //TODO log
                resultContact.Success = false;
                resultContact.Message = ex.Message + ex.StackTrace;
            }
            return resultContact;
        }

        public ManyResults<ContactIndexViewModel> GetAll()
        {
            ManyResults<ContactIndexViewModel> resultContact = new ManyResults<ContactIndexViewModel>();
            //try
            //{
                IList<ContactIndexViewModel> contactsView = new List<ContactIndexViewModel>();
                foreach(var conView in _contactService.GetAll())
                {
                    contactsView.Add(new ContactIndexViewModel(conView.ContactId,conView.FirstName + "   "+ conView.LastName));
                }
                resultContact.List = contactsView;
                resultContact.Success = true;
            //}
            //catch (Exception ex)
            //{
            //    //TODO log
            //    resultContact.Success = false;
            //}
            return resultContact;
        }

        public OneResult<Phone> AddPhone(Phone phone)
        {
            OneResult<Phone> resultContact = new OneResult<Phone>();
            try
            {
                if (_contactService.AddPhone(phone))
                {
                    resultContact.Success = true;
                    resultContact.Message = "Phone was add";
                }
                else
                {
                    resultContact.Success = false;
                    resultContact.Message = "Phone was not add";
                }
            }
            catch (Exception ex)
            {
                //TODO log
                resultContact.Success = false;
            }
            return resultContact;
        }

        public OneResult<Phone> DeletePhone(int id)
        {
            OneResult<Phone> resultContact = new OneResult<Phone>();
            try
            {
                if (_contactService.DeletePhone(id))
                {
                    resultContact.Success = true;
                    resultContact.Message = "Phone was delete";
                }
                else
                {
                    resultContact.Success = false;
                    resultContact.Message = "Phone was not delete";
                }
            }
            catch (Exception ex)
            {
                //TODO log
                resultContact.Success = false;
            }
            return resultContact;
        }

        public ManyResults<PhoneType> GetPhoneTypes()
        {
            ManyResults<PhoneType> resultContact = new ManyResults<PhoneType>();
            try
            {
                resultContact.List = _contactService.GetPhoneTypes();
                resultContact.Success = true;
            }
            catch(Exception ex)
            {
                //TODO log
                resultContact.Success = false;
            }
            return resultContact; 
        }

        public OneResult<Phone> EditPhone(Phone phone)
        {
            OneResult<Phone> resultContact = new OneResult<Phone>();
            try
            {
                if (_contactService.EditPhone(phone))
                {
                    resultContact.Success = true;
                    resultContact.Message = "Phone was edit";
                }
                else
                {
                    resultContact.Success = false;
                    resultContact.Message = "Phone was not edit";
                }
            }
            catch (Exception ex)
            {
                resultContact.Success = false;
            }
            return resultContact;
        }

        public OneResult<Phone> GetPhone(int id)
        {
            OneResult<Phone> resultContact = new OneResult<Phone>();
            try
            {
                Phone phone = _contactService.GetPhone(id);
                resultContact.Ob = phone;
                resultContact.Success = true;
            }
            catch (Exception ex)
            {
                resultContact.Success = false;
            }
            return resultContact;
        }

        public OneResult<ContactLogViewModel> Authorize(ContactLogViewModel contactView)
        {
            OneResult<ContactLogViewModel> resultContact = new OneResult<ContactLogViewModel>();
            try
            {
                if (_contactService.Authorize(contactView.Login, contactView.Password))
                {
                    resultContact.Success = true;
                }
                else
                {
                    resultContact.Success = false;
                    resultContact.Message = "This user does not exist";
                }
            }
            catch (Exception ex)
            {
                resultContact.Success = false;
            }
            return resultContact;
        }

        public OneResult<ContactViewModel> GetContactByLogin(string login)
        {
            OneResult<ContactViewModel> resultContact = new OneResult<ContactViewModel>();
            try
            {
                Contact contact = _contactService.FindContactByLogin(login);
                resultContact.Ob = ToViewModel.ToContactViewModel(contact);
                resultContact.Success = true;
            }
            catch (Exception ex)
            {
                resultContact.Success = false;
                resultContact.Message = ex.Message + " " + ex.StackTrace;
            }
            return resultContact;
        }   
    }
}
