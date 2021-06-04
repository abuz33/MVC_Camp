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
    public class TestimonialManager : ITestimonialService
    {
        private ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public List<Testimonial> GetList()
        {
            return _testimonialDal.List();
        }

        public Testimonial GetById(int id)
        {
            return _testimonialDal.Get(x => x.TestimonialId == id);
        }

        public void TestimonialAddBl(Testimonial testimonial)
        {
            _testimonialDal.Insert(testimonial);
        }

        public void TestimonialDelete(Testimonial testimonial)
        {
            _testimonialDal.Delete(testimonial);
        }

        public void TestimonialUpdate(Testimonial testimonial)
        {
            _testimonialDal.Update(testimonial);
        }
    }
}
