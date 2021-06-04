using MVC_Camp.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.Ajax.Utilities;

namespace MVC_Camp.Controllers
{
    public class ChartController : Controller
    {
        private HeadingManager hm = new HeadingManager(new EfHeadingDal());
        private CategoryManager cm = new CategoryManager(new EfCategoryDal());

        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }


        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> ct = new List<CategoryClass>();

            var values = cm.GetList();
            foreach (var item in values)
            {
                var num = hm.GetHeadingCountInCategory(item.CategoryName);
                ct.Add(new CategoryClass() { CategoryName = item.CategoryName, CategoryCount = num });
            }

            return ct;
        }
    }
}