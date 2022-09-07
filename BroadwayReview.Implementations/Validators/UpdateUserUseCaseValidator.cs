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
    public class UpdateUserUseCaseValidator : AbstractValidator<UpdateUserUseCaseDTO>
    {
        public UpdateUserUseCaseValidator(BroadwayReviewContext context)
        {
            RuleFor(x => x.UserId)
                .Must(x => context.Users.Any(z => z.Id == x && z.IsActive))
                .WithMessage("User with provided id does not exist.");
            RuleFor(x => x.UseCaseIds)
                .NotEmpty()
                .WithMessage("UseCaseIds must not be empty.")
                .Must(x => x.Distinct().Count() == x.Count())
                .WithMessage("UseCaseIds must not contain duplicates.");
        }
    }
}
