using AddressBook.Interfaces.Models;
using System.Web.Mvc;
using AddressBook.BLL.Service;
using AddressBook.BLL.Models;
using System.Web.Security;
using System.Web;
using System.Linq;
using System;

namespace AddressBookMVC.Controllers
{
    
    public class ContactController : Controller
    {
        private int PageSize = 4;
        ContactService _contactService = new ContactService();

        //[Authorize]
        public ActionResult Index(int page = 1)
        {
            var result = _contactService.GetAll();
            if (result.Success)
            {
                var model = new PagingContactsIndexViewModel
                {
                    Contacts = result.List.OrderBy(c => c.Id).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = result.List.Count()
                    }
                };
                return View(model);
            }
            else
            {
                return View("/Views/Shared/Error.cshtml");
            }
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View("SignUp");
        }

        [HttpPost]
        public ActionResult SignUp(ContactViewModel contactModel, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    contactModel.ImageMimeType = image.ContentType;
                    contactModel.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(contactModel.ImageData, 0, image.ContentLength);
                }
                var result = _contactService.Create(contactModel);
                if (result.Success)
                {
                    return RedirectToAction("Index", "Contact");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                    return View("SignUp", contactModel);
                }
            }
            else
            return View("SignUp", contactModel);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit()
        {
            var result = _contactService.GetContactByLogin(User.Identity.Name);
            if (result.Success)
            {
                return View("Edit", result.Ob);
            }
            return View("/Views/Shared/Error.cshtml");
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(ContactViewModel contact, HttpPostedFileBase file = null)
        { 
            if (ModelState.IsValid)
            {
                if (file != null)
            {
                contact.ImageData = new byte[file.ContentLength];
                contact.ImageMimeType = file.ContentType;
                file.InputStream.Read(contact.ImageData, 0, file.ContentLength);
            }

            var result = _contactService.EditContact(contact);
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
              
                
                else
                    return View("/Views/Shared/Error.cshtml", (object)result.Message);
            }
            return View("Edit", contact);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var result = _contactService.Get(id);
            if (result.Success)
            {
                //_contactService.DeleteContact(id);f
                return RedirectToAction("Index");
            }
            return View("/Views/Shared/Error.cshtml", (object)result.Message);
        }

        [Authorize]
        public ActionResult Detail(int id)
        {
            var result = _contactService.Get(id);
            if (result.Success)
            {
                return View("Detail", result.Ob);
            }
            return View("/Views/Shared/Error.cshtml", (object)result.Message);
        }

        [HttpGet]
        [Authorize]
        public ActionResult AddPhone(int id)
        {
            var result = _contactService.GetPhoneTypes();
            if (result.Success)
            {
                ViewBag.PhoneTypes = new SelectList(result.List, "PhoneTypeId", "Name");
                ViewData["Id"] = id;
                return PartialView();
        }
            return View("/Views/Shared/Error.cshtml", (object)result.Message);
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddPhone(Phone phone)
        {
            var result = _contactService.GetPhoneTypes();
            if (result.Success)
            {
                ViewBag.PhoneTypes = new SelectList(result.List, "PhoneTypeId", "Name",phone.PhoneTypeId);
                var result2 = _contactService.AddPhone(phone);
                if(result2.Success)
                {
                    return /*RedirectToAction("Edit")*/null;
                }
                return View("/Views/Shared/Error.cshtml", (object)result2.Message);
            }
            return View("/Views/Shared/Error.cshtml", (object)result.Message);
        }

        [HttpGet]
        [Authorize]
        public ActionResult EditPhone(int phoneId, int contactId)
        {
            var result = _contactService.GetPhoneTypes();
            if (result.Success)
            {
                ViewBag.PhoneTypes = new SelectList(result.List, "PhoneTypeId", "Name");
                ViewData["Id"] = contactId;
                var result2 = _contactService.GetPhone(phoneId);
                if (result2.Success)
                {
                    return PartialView("EditPhone", result2.Ob);
                }
                return View("/Views/Shared/Error.cshtml", (object)result2.Message);
            }
            return View("/Views/Shared/Error.cshtml", (object)result.Message);
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditPhone(Phone phone)
        {
            var result = _contactService.GetPhoneTypes();
            if (result.Success)
            {
                ViewBag.PhoneTypes = new SelectList(result.List, "PhoneTypeId", "Name", phone.PhoneTypeId);
                var result2 = _contactService.EditPhone(phone);
                if (result2.Success)
                {
                    return RedirectToAction("Edit");
                }
                return View("/Views/Shared/Error.cshtml", (object)result2.Message);
            }
            return View("/Views/Shared/Error.cshtml", (object)result.Message);
        }

        public ActionResult DeletePhone(int id)
        {
            var result = _contactService.DeletePhone(id);
            if (result.Success)
            {
                return null;
            }
            return View("/Views/Shared/Error.cshtml", (object)result.Message);
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn");
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View("LogIn");
        }

        [HttpPost]
        public ActionResult LogIn(ContactLogViewModel user)
        {
            var result = _contactService.Authorize(user);
            if (result.Success)
            {
                FormsAuthentication.SetAuthCookie(user.Login, false);
                return RedirectToAction("Index", "Contact");
            }
            return View("LogIn");
        }

        public FileContentResult GetImage(int contactId)
        {
            var result = _contactService.Get(contactId);
            if (result.Success)
            {
                return File(result.Ob.ImageData, result.Ob.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}