using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace MVC_Camp.Controllers
{
    public class AuthorizationController : Controller
    {
        private AdminManager adminManager = new AdminManager(new EfAdminDal());

        public ActionResult Index()
        {
            var values = adminManager.GetList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            adminManager.AdminAddBl(admin);
            return RedirectToAction("Index");
        }
    }
}