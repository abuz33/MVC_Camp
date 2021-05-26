using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        List<About> GetList();
        About GetById(int id);
        void AboutAddBl(About about);
        void AboutDelete(About about);
        void AboutUpdate(About about);
    }
}
