using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(c => c.ColorName).NotEmpty();
            RuleFor(c => c.ColorName).MinimumLength(3);
            RuleFor(c => c.ColorName).Must(StartsWithUpper).WithMessage("Lütfen girdiğiniz rengin ilk harfini büyük yazınız!");
        }

        private bool StartsWithUpper(string arg)
        {
            char c = arg[0];
            return Char.IsUpper(c);
        }
    }
}
