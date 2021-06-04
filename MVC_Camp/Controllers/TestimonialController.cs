using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace MVC_Camp.Controllers
{
    public class TestimonialController : Controller
    {
        private TestimonialManager tm = new TestimonialManager(new EfTestimonialDal());
        public ActionResult Index()
        {
            var values = tm.GetList();
            return View(values);
        }

        public ActionResult UpdateTestimonial(int id)
        {
            var testimonial = tm.GetById(id);
            switch (testimonial.Approved)
            {
                case true:
                    testimonial.Approved = false;
                    break;
                case false:
                    testimonial.Approved = true;
                    break;

            }
            tm.TestimonialUpdate(testimonial);
            return RedirectToAction("Index");
        }

        public ActionResult AddTestimonial()
        {
            return View();
        }
    }
}