using System;
using System.Linq;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System.Web.Mvc;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace MVC_Camp.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        DraftMessageManager dfm = new DraftMessageManager(new EfDraftMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        DraftController df = new DraftController();


        public ActionResult Inbox(string p)
        {
            string mail = (string)Session["WriterMail"];
            var messageList = mm.GetListInbox(mail);
            return View(messageList);
        }
        public ActionResult SentBox()
        {
            var messageList = mm.GetListSentBox("aalaca.33@gmail.com");
            return View(messageList);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult NewMessage(Message message, string button)
        {

            ValidationResult results = messageValidator.Validate(message);
            if (results.IsValid)
            {
                if (button == "draft")
                {
                    DraftMessage draftMessage = new DraftMessage();
                    draftMessage.ReceiverMail = message.ReceiverMail;
                    draftMessage.Subject = message.Subject;
                    draftMessage.MessageContent = message.MessageContent;
                    df.AddDraftMessage(draftMessage);

                    return RedirectToAction("Index", "Draft");
                }
                else if (button == "send")
                {
                    message.SentDate = DateTime.Now;
                    message.SenderMail = "admin@gmail.com";
                    mm.MessageAddBl(message);
                    return RedirectToAction("SentBox");
                }
            }
            else
            {
                foreach (var error in results.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var messageValue = mm.GetById(id);
            if (messageValue.IsRead == false)
            {
                messageValue.IsRead = true;
                mm.MessageUpdate(messageValue);
            }
            return View(messageValue);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var messageValue = mm.GetById(id);
            if (messageValue.IsRead == false)
            {
                messageValue.IsRead = true;
                mm.MessageUpdate(messageValue);
            }
            return View(messageValue);
        }
    }
}