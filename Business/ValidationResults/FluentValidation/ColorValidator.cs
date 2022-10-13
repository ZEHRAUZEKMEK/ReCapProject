using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationResults.FluentValidation
{
    public class ColorValidator:AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(cl => cl.Name).NotEmpty();
            RuleFor(cl => cl.Id).NotEmpty();
            
        }
    }
}
