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
    public class CreateGenreValidator : AbstractValidator<CreateGenreDTO>
    {
        private BroadwayReviewContext _context;
        public CreateGenreValidator(BroadwayReviewContext context)
        {
            _context = context;
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name is a required parameter.")
                .MinimumLength(4).WithMessage("Name length must be over 3 characters")
                .Must(x => !_context.Genres.Any(y => y.Name == x))
                .WithMessage("Genre {PropertyValue} is already in use.");


        }
    }
}
