using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        int GetHeadingCountInCategory(string CatName);
        List<Heading> GetListByWriter(int id);
        void HeadingAdd(Heading heading);
        Heading GetById(int id);
        void DeleteHeading(Heading heading);
        void UpdateHeading(Heading heading);
    }
}
