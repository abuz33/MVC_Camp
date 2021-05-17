using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Category name cannot be empty.");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Category name cannot be less than 3 characters.");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Category name cannot be more than 50 characters.");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Category description cannot be empty.");
        }
    }
}
