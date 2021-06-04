using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace MVC_Camp.Controllers
{

    public class ContactController : Controller
    {
        Context context = new Context();

        private DraftMessageManager dfm = new DraftMessageManager(new EfDraftMessageDal());
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactValidator cv = new ContactValidator();
        
        public ActionResult Index()
        {
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValue = cm.GetById(id);
            if (contactValue.IsRead == false)
            {
                contactValue.IsRead = true;
                cm.ContactUpdate(contactValue);
            }
            return View(contactValue);
        }

        public PartialViewResult ContactLeftPart()
        {
            ViewBag.ContactMailCount = cm.GetUnread().Count();
            ViewBag.MailCount = mm.GetListInbox("aalaca.33@gmail.com").Count();
            ViewBag.SentMailCount = mm.GetListSentBox("aalaca.33@gmail.com").Count();
            ViewBag.DraftMailCount = dfm.GetList("aalaca.33@gmail.com").Count();
            return PartialView();
        }
    }
}