using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace MVC_Camp.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterValidator writerValidator = new WriterValidator();
        private WriterManager wm = new WriterManager(new EfWriterDal());
        private TestimonialManager tm = new TestimonialManager(new EfTestimonialDal());
        TestimonialValidator testimonialValidator = new TestimonialValidator();


        public ActionResult MyProfile()
        {
            string p = (string)Session["WriterMail"];
            var id = wm.GetWriterId(p);
            var writerValue = wm.GetById(id);
            return View(writerValue);
        }

        [HttpGet]
        public ActionResult WriterProfile()
        {
            string p = (string)Session["WriterMail"];
            var id = wm.GetWriterId(p);
            var writerValue = wm.GetById(id);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {

            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid)
            {
                wm.UpdateWriter(writer);
                return RedirectToAction("AllHeadings");
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
        public ActionResult MyHeadings(String p)
        {
            p = (string)Session["WriterMail"];
            var writeridinfo = wm.GetWriterId(p);
            var values = hm.GetListByWriter(writeridinfo);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem()
                                                  {
                                                      Value = x.CategoryId.ToString(),
                                                      Text = x.CategoryName,
                                                  }).ToList();

            ViewBag.vlc = valuecategory;


            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string Writermail = (string)Session["WriterMail"];
            heading.HeadingCreateDateTime = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.HeadingStatus = true;
            heading.WriterId = wm.GetWriterId(Writermail);
            hm.HeadingAdd(heading);
            return RedirectToAction("MyHeadings");
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
            heading.HeadingStatus = true;
            hm.UpdateHeading(heading);
            return RedirectToAction("MyHeadings");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GetById(id);
            switch (headingValue.HeadingStatus)
            {
                case true:
                    headingValue.HeadingStatus = false;
                    break;
                case false:
                    headingValue.HeadingStatus = true;
                    break;

            }
            hm.DeleteHeading(headingValue);
            return RedirectToAction("MyHeadings");
        }

        public ActionResult AllHeadings(int page = 1)
        {
            var headings = hm.GetList().ToPagedList(page, 4);
            return View(headings);
        }

        public ActionResult Testimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Testimonial(Testimonial p)
        {
            ValidationResult results = testimonialValidator.Validate(p);
            if (results.IsValid)
            {
                var mail = (string)Session["WriterMail"];
                var writer = wm.GetByMail(mail);

                p.Name = writer.WriterName + " " + writer.WriterLastname;
                p.Date = DateTime.Now;
                tm.TestimonialAddBl(p);
                return RedirectToAction("MyProfile");
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
    }
}