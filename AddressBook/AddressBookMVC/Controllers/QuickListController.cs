using AddressBook.BLL.Service;
using AddressBook.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AddressBookMVC.Controllers
{
    [Authorize]
    public class QuickListController : Controller
    {
        QuickListService _quickListService = new QuickListService();
        ContactService _contactService = new ContactService();

        [HttpGet]
        public ActionResult Create()
        {
            int contactId = _contactService.GetContactByLogin(User.Identity.Name).Ob.ContactId;
            ViewData["contactId"] = contactId;
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(QuickList quickList)
        {
            var contentResult = _quickListService.Create(quickList);
            if (contentResult.Success)
            {
                return RedirectToAction("Index");
            }
            return View("/Views/Shared/Error.cshtml");
        }

        public ActionResult Index()
        {
            //var contentResult1 = _quickListService.GetContactByLogin(User.Identity.Name);
            //if (contentResult1.Success)
            //{
                var contentResult2 = _quickListService.GetAll(User.Identity.Name);
                if (contentResult2.Success)
                {
                    return View("Index", contentResult2.List);
                }
                return View("/Views/Shared/Error.cshtml");
            //}
            //return View("/Views/Shared/Error.cshtml", (object)contentResult1.ErrorMessage);
        }

        [HttpGet]
        public ActionResult ChooseQuickList(int ContactId)
        {
            var contactId = _contactService.GetContactByLogin(User.Identity.Name).Ob.ContactId;
            var result = _quickListService.GetQuickLists(contactId);
            if (result.Success)
            {
                ViewBag.QuickLists = new SelectList(result.List, "QuickListId", "Name");
                ViewData["Id"] = ContactId;
                return PartialView("ChooseQuickList");
            }
            return PartialView("AddToQuickList");
        }

        [HttpPost]
        public ActionResult ChooseQuickList(int ContactId, int QuickListId)
        {
            var result = _quickListService.AddContactToQuickList(ContactId, QuickListId);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            return View("/Views/Shared/Error.cshtml"/*, (object)result.Message*/);
        }
    }
}