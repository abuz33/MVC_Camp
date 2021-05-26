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
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem()
                                                  {
                                                      Value = x.CategoryId.ToString(),
                                                      Text = x.CategoryName,
                                                  }).ToList();
            List<SelectListItem> valuewriter = (from x in wm.GetList()
                                                select new SelectListItem()
                                                {
                                                    Value = x.WriterId.ToString(),
                                                    Text = x.WriterName + " " + x.WriterLastname,
                                                }).ToList();
            ViewBag.vlc = valuecategory;
            ViewBag.vlw = valuewriter;

            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingCreateDateTime = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(heading);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem()
                                                  {
                                                      Value = x.CategoryId.ToString(),
                                                      Text = x.CategoryName,
                                                  }).ToList();

            ViewBag.vlc = valuecategory;

            var HeadingValue = hm.GetById(id);
            return View(HeadingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            //heading.HeadingCreateDateTime = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.UpdateHeading(heading);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var HeadingValue = hm.GetById(id);
            switch (HeadingValue.HeadingStatus)
            {
                case true:
                    HeadingValue.HeadingStatus = false;
                    break;
                case false:
                    HeadingValue.HeadingStatus = true;
                    break;

            }
            hm.DeleteHeading(HeadingValue);
            return RedirectToAction("Index");
        }
    }
}