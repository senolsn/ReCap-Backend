using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).MinimumLength(2);

            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).MinimumLength(2);


            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).Must(ContainAtSymbol).WithMessage("Lütfen geçerli bir e mail adresi girin!");

            
        }

        private bool MustContainUppercase(string arg)
        {
            return arg.Any(char.IsUpper);
        }

        private bool ContainAtSymbol(string arg)
        {
            return arg.Contains("@");
        }
    }
}
