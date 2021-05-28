using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Email cannot be empty.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Name cannot be empty.");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Name cannot be less than 3 characters.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Subject cannot be empty.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Subject cannot be less than 3 characters.");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Subject cannot be more than 50 characters.");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Message cannot be empty.");
        }
    }
}
