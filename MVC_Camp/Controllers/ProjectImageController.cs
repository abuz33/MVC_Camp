using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;


namespace MVC_Camp.Controllers
{
    public class ProjectImageController : Controller
    {
        private ProjectImageManager pm = new ProjectImageManager(new EfProjectImages());
        public ActionResult Index()
        {
            var images = pm.GetList();
            return View(images);
        }

        [HttpGet]
        public ActionResult AddImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddImage(ProjectImage p)
        {
            if (Request.Files.Count > 0 )
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string ext = Path.GetExtension(Request.Files[0].FileName);
                string way = "~/Image/" + fileName + ext;
                Request.Files[0].SaveAs(Server.MapPath(way));
                p.ImagePath= "/Image/" + fileName + ext;
            }

            pm.ProjectImageAddBl(p);
            
            return RedirectToAction("Index");
        }
    }
}