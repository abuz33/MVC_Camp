using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetList();
        void AddWriter(Writer writer);
        void DeleteWriter(Writer writer);
        void UpdateWriter(Writer writer);

        Writer GetById(int id);
    }
}
