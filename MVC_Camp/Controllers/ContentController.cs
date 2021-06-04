using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace MVC_Camp.Controllers
{
    public class ContentController : Controller
    {
        private ContentManager cm = new ContentManager(new EfContentDal());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContent(string p = "")
        {
            //p = "One";
            var values = cm.GetListByParameter(p);

            //var values = cm.GetList();
            return View(values.ToList());
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentvalues = cm.GetListByHeadingId(id);
            return View(contentvalues);
        }
    }
}