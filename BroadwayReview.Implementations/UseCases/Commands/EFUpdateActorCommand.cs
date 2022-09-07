using BroadwayReview.Application.DTO;
using BroadwayReview.Application.Exceptions;
using BroadwayReview.Application.UseCases.Commands;
using BroadwayReview.DataAccess;
using BroadwayReview.Domain.Entities;
using BroadwayReview.Implementations.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Implementations.UseCases.Commands
{
    public class EFUpdateActorCommand : EFUseCaseConnection, IUpdateActorCommand
    {
        private readonly UpdateActorValidator _validator;
        public EFUpdateActorCommand(BroadwayReviewContext context, UpdateActorValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 23;

        public string Name => "Use case for updating an actor.";

        public string Description => "Use case for updating an actor with EF.";

        public void Execute(UpdateActorDTO request)
        {
            _validator.ValidateAndThrow(request);
            var actor = Context.Actors.FirstOrDefault(x => x.Id == request.Id && x.IsActive);
            if (actor == null)
            {
                throw new EntityNotFoundException(nameof(Actor), (int)request.Id);
            }
            actor.Name = request.Name;
            Context.SaveChanges();
        }
    }
}
