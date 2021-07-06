using System.Collections.Generic;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.HelperClass;
using DataAccessLayer.EntityFramework;
using Newtonsoft.Json;

namespace MVC_Camp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private WriterLoginManager _wm = new WriterLoginManager(new EfWriterDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context c = new Context();
            var adminUserInfo = c.Admins.FirstOrDefault(x =>
                x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);
            if (adminUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName, false);
                Session["AdminUserName"] = adminUserInfo.AdminUserName;
                Session["AuthRole"] = adminUserInfo.AdminRole;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            var response = Request["g-recaptcha-response"];
            const string secret = "6LfHFTwbAAAAAB53V5ZcixAgVCi2aTXIuF-eLxF9";
            var client = new WebClient();

            var reply = client.DownloadString(
                $"https://www.google.com/recaptcha/api/siteverify?secret={secret}&response={response}");
            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);
            if (!captchaResponse.Success)
            {
                ViewBag.ErrorMessage = "User name or Password is wrong!";
                return View();
            }

            var pass = PasswordHashing.Encrypt(p.WriterPassword);
            var userInfo = _wm.GetWriter(p.WriterMail, pass);

            if (userInfo != null)
            {
                FormsAuthentication.SetAuthCookie(userInfo.WriterMail, false);
                Session["WriterMail"] = userInfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }

        public class CaptchaResponse
        {
            [JsonProperty("success")]
            public bool Success { get; set; }

            [JsonProperty("error-codes")]
            public List<string> ErrorCodes { get; set; }
        }
    }
}