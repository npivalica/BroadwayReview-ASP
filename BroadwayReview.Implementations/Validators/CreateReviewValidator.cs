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
    public class CreateReviewValidator : AbstractValidator<ReviewDTO>
    {
        private BroadwayReviewContext _context;
        public CreateReviewValidator(BroadwayReviewContext context)
        {
            _context = context;
            RuleFor(x => x.UserId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("UserId is required parameter")
                .Must(x => context.Users.Any(y => y.Id == x && y.IsActive))
                .WithMessage("There is no user with a provided Id");
            RuleFor(x => x.PlayId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().
                WithMessage("PlayId is required parameter")
                .Must(x => context.Plays.Any(y => y.Id == x && y.IsActive))
                .WithMessage("There is no play with a provided Id");
            RuleFor(x => x.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Review title is required parameter.")
                .MaximumLength(70).WithMessage("Please use up to 70 characters."); ;
            RuleFor(x => x.Text)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Text of the review is required parameter")
                .MaximumLength(250).WithMessage("Please use up to 250 characters.");
            RuleFor(x => x.PlayRating)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Rating is a required parameter")
                .InclusiveBetween(1, 5)
                .WithMessage("Rate between 1 and 5");


        }
    }
}
