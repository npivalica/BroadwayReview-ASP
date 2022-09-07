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
    public class UpdateActorValidator : AbstractValidator<UpdateActorDTO>
    {
        private BroadwayReviewContext _context;
        public UpdateActorValidator(BroadwayReviewContext context)
        {
            _context = context;
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Name is required parameter.")
                .MinimumLength(4)
                .WithMessage("Name length must be over 3 charachters")
                .Must(x => !_context.Actors.Any(y => y.Name == x))
                .WithMessage("Actor {PropertyValue} is already in use.");
        }
    }
}
