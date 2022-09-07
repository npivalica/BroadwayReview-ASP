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
    public class CreatePlayValidator : AbstractValidator<CreatePlayDTO>
    {
        private BroadwayReviewContext _context;
        public CreatePlayValidator(BroadwayReviewContext context)
        {
            _context = context;
            RuleFor(x => x.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Play title is required parameter.");
            RuleFor(x => x.Year)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .GreaterThan(1866)
                .WithMessage("First play was made in 1866, not before that");
            RuleFor(x => x.Duration)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Duration must be longer than 0 minutes");
            RuleFor(x => x.Description)
                .Length(5, 150)
                .WithMessage("Play description length must be between 5 and 150 characters.");
            RuleFor(x => x.AuthorId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Play author is required parameter.")
                .Must(x => context.Authors.Any(y => y.Id == x))
                .WithMessage("There is no author with provided Id");
            RuleFor(x => x.PlayGenreIds)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("PlayGenreIds parameter must have a value")
                .Must(x => x.Count() == x.Distinct().Count())
                .WithMessage("There is a duplicates in the set of the provided ids.");
            RuleForEach(x => x.PlayGenreIds)
                .NotEmpty()
                .WithMessage("Every provided id must have a value")
                .Must(x => context.Genres.Any(z => z.Id == x))
                .WithMessage("There is no genre with provided Id {PropertyValue}");


        }
    }
}
