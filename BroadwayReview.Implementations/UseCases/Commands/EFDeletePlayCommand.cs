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
    public class EFDeletePlayCommand : EFUseCaseConnection, IDeletePlayCommand
    {
        public EFDeletePlayCommand(BroadwayReviewContext context) : base(context)
        {
        }

        public int Id => 12;

        public string Name => "Use case for deleting a play.";

        public string Description => "Use case for deleting a play with EF.";

        public void Execute(int request)
        {
            var play = Context.Plays.Include(x => x.PlayGenres)
                                    .Include(x => x.ActorPlays)
                                    .FirstOrDefault(x => x.Id == request && x.IsActive);
            if (play == null)
            {
                throw new EntityNotFoundException(nameof(Play), request);
            }
            var playGenres = Context.PlayGenres.Where(x => x.PlayId == request);
            var playActors = Context.ActorPlays.Where(x => x.PlayId == request);
            Context.RemoveRange(playGenres);
            Context.RemoveRange(playActors);
            play.IsActive = false;
            play.DeletedAt = DateTime.UtcNow;
            Context.SaveChanges();
        }
    }
}
