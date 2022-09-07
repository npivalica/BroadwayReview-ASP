using BroadwayReview.Application;
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
    public class EFCreateActorCommand : EFUseCaseConnection, ICreateActorCommand
    {
        private CreateActorValidator _validator;
        public EFCreateActorCommand(BroadwayReviewContext context, CreateActorValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 18;

        public string Name => "Use case for creating an actor";

        public string Description => "Use case for creating an actor with EF";

        public void Execute(ActorDTO request)
        {
            _validator.ValidateAndThrow(request);
            var actor = new Actor
            {
                Name = request.Name
            };
            Context.Add(actor);
            Context.SaveChanges();
        }
    }
}
