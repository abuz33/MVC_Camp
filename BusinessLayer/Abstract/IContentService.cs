using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();
        List<Content> GetListByParameter(string p);
        List<Content> GetListByHeadingId(int Id);
        List<Content> GetListByWriter(int Id);
        Content GetById(int id);
        void ContentAddBl(Content content);
        void ContentDelete(Content content);
        void ContentUpdate(Content content);
    }
}
