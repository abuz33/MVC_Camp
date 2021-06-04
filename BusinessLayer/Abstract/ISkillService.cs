using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
   public interface ISkillService
    {
        List<Skill> GetListByWriterId(int id);
        Skill GetById(int id);
        void SkillAddBl(Skill skill);
        void SkillDelete(Skill skill);
        void SkillUpdate(Skill skill);
    }
}
