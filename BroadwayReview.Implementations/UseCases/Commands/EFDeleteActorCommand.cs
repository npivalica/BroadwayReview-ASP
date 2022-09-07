using BroadwayReview.Application.Exceptions;
using BroadwayReview.Application.UseCases.Commands;
using BroadwayReview.DataAccess;
using BroadwayReview.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Implementations.UseCases.Commands
{
    public class EFDeleteActorCommand : EFUseCaseConnection, IDeleteActorCommand
    {
        public EFDeleteActorCommand(BroadwayReviewContext context) : base(context)
        {
        }

        public int Id => 21;

        public string Name => "Use case for deleting an actor";

        public string Description => "Use case for deleting an actor with EF";

        public void Execute(int request)
        {
            var actor = Context.Actors.Include(x => x.ActorPlays).FirstOrDefault(x => x.Id == request && x.IsActive);
            if (actor == null)
            {
                throw new EntityNotFoundException(nameof(Actor), request);
            }
            if (actor.ActorPlays.Any())
            {
                throw new UseCaseConflictException("Deleting actor was denied because it contains plays that reference to it: " +
                    string.Join(", ", actor.ActorPlays.Select(x => x.PlayId)));
            }
            actor.DeletedAt = DateTime.Now;
            actor.IsActive = false;
            Context.SaveChanges();
        }
    }
}
