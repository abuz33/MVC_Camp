using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class TestimonialValidator : AbstractValidator<Testimonial>
    {
        public TestimonialValidator()
        {
            RuleFor(x => x.TestimonialContent).NotEmpty().WithMessage("Testimonial Content Cannot Be Empty.");
            RuleFor(x => x.TestimonialContent).MaximumLength(1000).WithMessage("Testimonial Content Cannot Be More Than 1000 Characters.");
            RuleFor(x => x.TestimonialContent).MinimumLength(3).WithMessage("Testimonial Content Cannot Be Less Than  Characters.");
        }
    }
}
