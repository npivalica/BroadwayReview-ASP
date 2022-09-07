using BroadwayReview.Application.DTO;
using BroadwayReview.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Implementations.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDTO>
    {
        private BroadwayReviewContext _context;
        public RegisterUserValidator(BroadwayReviewContext context)
        {
            _context = context;
            var nameRegex = "^[A-Z][a-z]{2,}(\\s[A-Z][a-z]{2,})*$";
            RuleFor(x => x.Username)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Username is a required parameter")
                .MinimumLength(3)
                .WithMessage("Username must have at least 3 characters")
                .MaximumLength(20)
                .WithMessage("Username cannot have more than 20 characters")
                .Matches("^(?=[a-zA-Z0-9._]{3,20}$)(?!.*[_.]{2})[^_.].*[^_.]$")
                .WithMessage("Username can have letters, numbers and _ (lower dash)")
                .Must(x => !_context.Users.Any(y => y.Username == x))
                .WithMessage("Username {PropertyValue} already exists.");


            RuleFor(x => x.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("First name is a required parameter.")
                .MaximumLength(50)
                .WithMessage("First name cannot be longer than 50 characters.")
                .Matches(nameRegex)
                .WithMessage("First name must have at least 3 sharacters and it must begin with an uppercase letter.");

            RuleFor(x => x.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Last name is a required parameter.")
                .MaximumLength(50)
                .WithMessage("Last name cannot be longer than 50 characters.")
                .Matches(nameRegex).WithMessage("First name must have at least 3 sharacters and it must begin with an uppercase letter.");


            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Email is a required parameter.")
                .EmailAddress()
                .WithMessage("{PropertyValue} is not a valid email address")
                .Must(x => !_context.Users.Any(y => y.Email == x))
                .WithMessage("Email {PropertyValue} already exists.");

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Password is a required parameter.")
                .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$")
                .WithMessage("Password must have at least one small letter, one big letter, a number and a special character.");
        }
    }
}
