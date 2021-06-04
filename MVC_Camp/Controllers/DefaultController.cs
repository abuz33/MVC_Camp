using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace MVC_Camp.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private HeadingManager hm = new HeadingManager(new EfHeadingDal());
        private ContentManager cm = new ContentManager(new EfContentDal());

        public ActionResult Headings()
        {
            var headingValues = hm.GetList();
            return View(headingValues);
        }

        public PartialViewResult Index(int id = 0)
        {
            var contentvalues = cm.GetListByHeadingId(id);
            return PartialView(contentvalues);
        }
    }
}