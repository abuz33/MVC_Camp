﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class HeadingManager:IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }
        
        public List<Heading> GetList()
        {
            return _headingDal.List();
        }

        public void HeadingAdd(Heading heading)
        {
            _headingDal.Insert(heading);
        }

        public Heading GetById(int id) => _headingDal.Get(p => p.HeadingId == id);

        public void DeleteHeading(Heading heading) => _headingDal.Update(heading);

        public void UpdateHeading(Heading heading)
        {
            _headingDal.Update(heading);
        }
    }
}
