using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace MVC_Camp.Controllers
{
    public class WriterPanelContentController : Controller
    {
        private ContentManager cm = new ContentManager(new EfContentDal());
        private WriterManager wm = new WriterManager(new EfWriterDal());

        public ActionResult MyContent(string p)
        {
            p = (string)Session["WriterMail"];
            var writeridinfo = wm.GetWriterId(p);

            var contentValues = cm.GetListByWriter(writeridinfo);
            return View(contentValues);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {

            var p = (string)Session["WriterMail"];
            var writeridinfo = wm.GetWriterId(p);

            content.ContentDate = DateTime.Now;
            content.WriterId = writeridinfo;
            content.ContentStatus = true;

            cm.ContentAddBl(content);
            return RedirectToAction("MyContent");
        }
    }
}