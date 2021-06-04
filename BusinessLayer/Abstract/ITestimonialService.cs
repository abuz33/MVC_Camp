using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ITestimonialService
    {
        List<Testimonial> GetList();
        Testimonial GetById(int id);
        void TestimonialAddBl(Testimonial testimonial);
        void TestimonialDelete(Testimonial testimonial);
        void TestimonialUpdate(Testimonial testimonial);
    }
}
