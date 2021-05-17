using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Concrete;

namespace MVC_Camp.Controllers
{
    public class StatisticsController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            var totalCategories = context.Categories.Count();
            Console.WriteLine(totalCategories);
            var headingsInDevelopment = context.Headings.Count(x => x.CategoryId == 8);
            var aInWriterName = context.Writers.Count(x => x.WriterName.Contains("a"));
            var mostHeadingsCategory = context.Categories.Where(u => u.CategoryId == context.Headings.GroupBy(x => x.CategoryId).OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
            var activeCategories = context.Categories.Count(x => x.CategoryStatus == true);
            var passiveCategories = context.Categories.Count(x => x.CategoryStatus == false);

            ViewBag.totalCategories = totalCategories;
            ViewBag.headingsInDevelopment = headingsInDevelopment;
            ViewBag.aInWriterName = aInWriterName;
            ViewBag.mostHeadingsCategory = mostHeadingsCategory;
            if (activeCategories > passiveCategories)
            {
                ViewBag.totalCategory = activeCategories - passiveCategories;
                ViewBag.messageForcategories = "There are more active Categories.";
            }
            else
            {
                ViewBag.totalCategory = passiveCategories - activeCategories;
                ViewBag.messageForcategories = "There are more passive Categories.";
            }

            return View();
        }
    }
}