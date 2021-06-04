using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MVC_Camp.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        private readonly MessageManager _mm = new MessageManager(new EfMessageDal());
        private WriterManager _wm = new WriterManager(new EfWriterDal());
        private readonly DraftMessageManager _dfm = new DraftMessageManager(new EfDraftMessageDal());
        readonly MessageValidator _messageValidator = new MessageValidator();
        private readonly DraftController _df = new DraftController();

        public ActionResult Inbox()
        {
            string mail = (string)Session["WriterMail"];
            ViewBag.DraftMail = _dfm.GetList(mail).Count;

            var messageList = _mm.GetListInbox(mail);
            return View(messageList);
        }

        public PartialViewResult MessageListMenu()
        {
            var mail = (string)Session["WriterMail"];
            ViewBag.MailCount = _mm.GetListInbox(mail).Count();
            ViewBag.SentMailCount = _mm.GetListSentBox(mail).Count();
            ViewBag.DraftMailCount = _dfm.GetList(mail).Count();

            ViewBag.DraftMail = _dfm.GetList(mail).Count;
            ViewBag.p = mail;
            return PartialView();
        }

        public ActionResult SendBox(string p)
        {
            p = (string)Session["WriterMail"];
            var messageList = _mm.GetListSentBox(p);
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
            var writermail = (string)Session["WriterMail"];

            ValidationResult results = _messageValidator.Validate(message);
            if (results.IsValid)
            {
                if (button == "draft")
                {
                    DraftMessage draftMessage = new DraftMessage
                    {
                        ReceiverMail = message.ReceiverMail,
                        Subject = message.Subject,
                        MessageContent = message.MessageContent
                    };
                    _df.AddDraftMessage(draftMessage);

                    return RedirectToAction("Inbox", "WriterPanelMessage");
                }
                else if (button == "send")
                {
                    message.SentDate = DateTime.Now;
                    message.SenderMail = writermail;
                    _mm.MessageAddBl(message);
                    return RedirectToAction("SendBox");

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
            var messageValue = _mm.GetById(id);
            if (messageValue.IsRead == false)
            {
                messageValue.IsRead = true;
                _mm.MessageUpdate(messageValue);
            }
            return View(messageValue);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var messageValue = _mm.GetById(id);
            if (messageValue.IsRead == false)
            {
                messageValue.IsRead = true;
                _mm.MessageUpdate(messageValue);
            }
            return View(messageValue);
        }

        public ActionResult Draft()
        {
            return View();
        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}