using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationResults.FluentValidation
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(cs => cs.UserId).NotEmpty();
            RuleFor(cs => cs.CompanyName).Must(StartWithR);

        }

        private bool StartWithR(string arg)
        {
            return arg.StartsWith("R");
        }
    }
}
