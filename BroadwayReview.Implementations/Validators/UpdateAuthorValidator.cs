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
    public class UpdateAuthorValidator : AbstractValidator<AuthorDTO>
    {
        private BroadwayReviewContext _context;
        public UpdateAuthorValidator(BroadwayReviewContext context)
        {
            _context = context;
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name is a required parametar.")
                .MinimumLength(4).WithMessage("Name length must be over 3 characters");
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .Must(x => _context.Authors.Any(z => z.Id == x))
                .WithMessage("Author with an id {PropertyValue} doesn't exist.");
            RuleFor(x => x)
                .Must(x => !_context.Authors
                .Any(y => y.Name == x.Name && x.Id != y.Id))
                .WithMessage("Author with a given name is already in use.");
        }
    }
}
