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
            //RuleFor(c=>c.ColorId).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();
           // RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.Description).MinimumLength(10);

        }

        
    }
}
