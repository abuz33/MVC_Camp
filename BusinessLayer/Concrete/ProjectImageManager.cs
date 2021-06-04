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
    public class ProjectImageManager: IProjectImageService
    {
        private readonly IProjectImageDal _projectImageDal;

        public ProjectImageManager(IProjectImageDal projectImageDal)
        {
            _projectImageDal = projectImageDal;
        }

        public List<ProjectImage> GetList()
        {
            return _projectImageDal.List();
        }

        public ProjectImage GetById(int id)
        {
            return _projectImageDal.Get(x => x.ImageId == id);
        }

        public void ProjectImageAddBl(ProjectImage projectImage)
        {
            _projectImageDal.Insert(projectImage);
        }

        public void ProjectImageDelete(ProjectImage projectImage)
        {
            _projectImageDal.Delete(projectImage);
        }

        public void ProjectImageUpdate(ProjectImage projectImage)
        {
            _projectImageDal.Update(projectImage);
        }
    }
}
