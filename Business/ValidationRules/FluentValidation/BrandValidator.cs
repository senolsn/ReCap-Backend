using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator:AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b => b.BrandName).NotEmpty();
            RuleFor(b => b.BrandName).MinimumLength(3);
            RuleFor(b => b.BrandName).Must(StartsWithUpper).WithMessage("Lütfen girdiğiniz markanın ilk harfini büyük yazınız!");
        }

        private bool StartsWithUpper(string arg)
        {
            char b = arg[0];
            return Char.IsUpper(b);
        }
    }
}
