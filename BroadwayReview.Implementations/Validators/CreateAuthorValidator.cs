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
    public class CreateAuthorValidator : AbstractValidator<AuthorDTO>
    {
        private BroadwayReviewContext _context;
        public CreateAuthorValidator(BroadwayReviewContext context)
        {
            _context = context;
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name is a required parametar.")
                .MinimumLength(4).WithMessage("Name length must be over 3 characters")
                .Must(AuthorAlreadyExists).WithMessage("Author {PropertyValue} is already in use.");
        }
        private bool AuthorAlreadyExists(string name)
        {
            if (_context.Authors.Any(x => x.Name == name))
            {
                return false;
            }
            return true;
        }
    }
}
