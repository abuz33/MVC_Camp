using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Writer name cannot be empty.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Writer name cannot be less than 2 characters.");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Writer name cannot be more than 50 characters.");
            RuleFor(x => x.WriterLastname).NotEmpty().WithMessage("Writer last name cannot be empty.");
            RuleFor(x => x.WriterLastname).MinimumLength(2)
                .WithMessage("Writer last name cannot be less than 2 characters.");
            RuleFor(x => x.WriterLastname).MaximumLength(50)
                .WithMessage("Writer last name cannot be more than 50 characters.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("About writer cannot be empty.");
            //RuleFor(x=>x.WriterAbout).C.WithMessage("About writer cannot be empty.");

        }
    }
}
