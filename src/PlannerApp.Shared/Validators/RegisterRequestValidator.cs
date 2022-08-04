using FluentValidation;
using PlannerApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApp.Shared.Validators
{
    public class RegisterRequestValidator :AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(p => p.Email)
                .NotEmpty()
                .WithMessage("Wmail Ca not be Empty")
                .EmailAddress()
                .WithMessage("Email is not a valid Email Address");

            RuleFor(p => p.FirstName)
                .NotEmpty()
                .WithMessage("First Name Can not be Empty")
                .MaximumLength(25)
                .WithMessage("Length for First Name must be less than 25 characters");

            RuleFor(p=>p.LastName)
                     .NotEmpty()
                .WithMessage("Last Name Can not be Empty")
                .MaximumLength(25)
                .WithMessage("Length for Last Name must be less than 25 characters");

            RuleFor(p => p.Password)
                .NotEmpty()
                .WithMessage("Password can not be Empty")
                .MaximumLength(20)
                .WithMessage("Password must be less than 20 characters");

            RuleFor(p => p.ConfirmPassword)
                .Equal(p => p.Password)
                .WithMessage("Confirm Password does not match the Password");

        }
    }
}
