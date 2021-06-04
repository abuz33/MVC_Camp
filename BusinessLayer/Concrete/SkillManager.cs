using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class SkillManager:ISkillService
    {
        private ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public List<Skill> GetListByWriterId(int id)
        {
            return _skillDal.List(x => x.WriterId == id);
        }

        public Skill GetById(int id)
        {
            return _skillDal.Get(x => x.SkillId == id);
        }

        public void SkillAddBl(Skill skill)
        {
            _skillDal.Insert(skill);
        }

        public void SkillDelete(Skill skill)
        {
            _skillDal.Delete(skill);
        }

        public void SkillUpdate(Skill skill)
        {
            _skillDal.Update(skill);
        }
    }
}
