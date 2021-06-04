using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
   public interface IProjectImageService
    {
        List<ProjectImage> GetList();
        ProjectImage GetById(int id);
        void ProjectImageAddBl(ProjectImage projectImage);
        void ProjectImageDelete(ProjectImage projectImage);
        void ProjectImageUpdate(ProjectImage projectImage);
    }
}
