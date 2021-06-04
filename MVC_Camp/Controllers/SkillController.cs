using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace MVC_Camp.Controllers
{
    public class SkillController : Controller
    {
        SkillValidator skillValidator = new SkillValidator();
        private SkillManager sm = new SkillManager(new EfSkillDal());
        private WriterManager wm = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            string p = (string)Session["WriterMail"];
            var writeridinfo = wm.GetWriterId(p);
            var writer = wm.GetById(writeridinfo);
            ViewBag.writer = writer;
            var skillvalues = sm.GetListByWriterId(writeridinfo);
            return View(skillvalues);
        }

        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSkill(Skill skill)
        {
            ValidationResult results = skillValidator.Validate(skill);
            if (results.IsValid)
            {
                string p = (string)Session["WriterMail"];
                var writeridinfo = wm.GetWriterId(p);
                skill.WriterId = writeridinfo;
                sm.SkillAddBl(skill);
                return RedirectToAction("Index");
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