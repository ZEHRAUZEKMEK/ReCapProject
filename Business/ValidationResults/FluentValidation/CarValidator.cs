using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationResults.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c=>c.ColorId).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(100).When(c=>c.BrandId==15);
            RuleFor(c => c.Description).Must(StartWithF);

        }

        private bool StartWithF(string arg)
        {
            return arg.StartsWith("F");
        }
    }
}
