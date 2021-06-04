using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class SkillValidator : AbstractValidator<Skill>
    {
        public SkillValidator()
        {
            RuleFor(x => x.SkillName).NotEmpty().WithMessage("Skill name cannot be empty.");
            RuleFor(x => x.SkillName).MinimumLength(3).WithMessage("Skill name cannot be less than 3 characters.");
            RuleFor(x => x.SkillName).MaximumLength(20).WithMessage("Skill name cannot be more than 20 characters."); 
            RuleFor(a => a.SkillPoint).NotEmpty().WithMessage("Invalid Number.");
            RuleFor(x => x.SkillPoint).LessThanOrEqualTo(100).WithMessage("Skill point cannot be more than 100.");
            RuleFor(x => x.SkillPoint).GreaterThanOrEqualTo(0).WithMessage("Skill point cannot be less than 0.");
        }
    }
}
