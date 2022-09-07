using BroadwayReview.Application.DTO;
using BroadwayReview.Application.Exceptions;
using BroadwayReview.Application.UseCases.Queries;
using BroadwayReview.DataAccess;
using BroadwayReview.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Implementations.UseCases.Queries
{
    public class EfFindActorQuery : EFUseCaseConnection, IFindActorQuery
    {
        public EfFindActorQuery(BroadwayReviewContext context) : base(context)
        {
        }

        public int Id => 19;

        public string Name => "Use case for finding actors.";

        public string Description => "Use case for finding actors with EF.";

        public GetActorDTO Execute(int request)
        {
            var actor = Context.Actors.Include(x => x.ActorPlays)
                .ThenInclude(x => x.Play).FirstOrDefault(x => x.Id == request && x.IsActive);
            if (actor == null)
            {
                throw new EntityNotFoundException(nameof(Actor), (int)request);
            }
            return new GetActorDTO
            {
                Id = actor.Id,
                Name = actor.Name,
                Plays = actor.ActorPlays.Select(x => new PlayDTO
                {
                    Title = x.Play.Title,
                    Year = x.Play.Year,
                    Duration = x.Play.Duration
                })
            };
        }
    }
}
