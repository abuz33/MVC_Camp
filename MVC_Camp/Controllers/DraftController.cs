using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System.Web.Mvc;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace MVC_Camp.Controllers
{
    public class DraftController : Controller
    {
        private DraftMessageManager dfm = new DraftMessageManager(new EfDraftMessageDal());
        DraftMessageValidator messageValidator = new DraftMessageValidator();

        public ActionResult Index()
        {
            var draftMessageValues = dfm.GetList("aalaca.33@gmail.com");
            return View(draftMessageValues);
        }

        [HttpPost]
        public ActionResult AddDraftMessage(DraftMessage message)
        {
            message.SentDate = DateTime.Now;
            message.SenderMail = "admin@gmail.com";
            dfm.DraftMessageAddBl(message);

            return RedirectToAction("Index");
        }

        public ActionResult GetMessageDetails(int id)
        {
            var messageValues = dfm.GetById(id);
            return View(messageValues);
        }
    }
}