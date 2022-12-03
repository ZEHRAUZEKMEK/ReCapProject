using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationResults.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(us => us.FirstName).NotEmpty();
            RuleFor(us => us.Email).NotEmpty();
            RuleFor(us=>us.LastName).MinimumLength(5);
           

        }
    }
}
