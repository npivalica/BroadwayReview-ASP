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
    public class EfFindPlayQuery : EFUseCaseConnection, IFindPlayQuery
    {
        public EfFindPlayQuery(BroadwayReviewContext context) : base(context)
        {
        }

        public int Id => 11;

        public string Name => "Use case for finding plays.";

        public string Description => "Use case for finding plays with EF.";

        public ExtendedPlayDTO Execute(int request)
        {
            var play = Context.Plays.Include(x => x.Author)
                .Include(x => x.PlayGenres).
                ThenInclude(x => x.Genre).FirstOrDefault(x => x.Id == request && x.IsActive);
            if (play == null)
            {
                throw new EntityNotFoundException(nameof(Play), request);
            }
            return new ExtendedPlayDTO
            {
                Id = play.Id,
                Title = play.Title,
                Year = play.Year,
                Duration = play.Duration,
                Description = play.Description,
                Author = play.Author.Name,
                Genres = play.PlayGenres.Select(x => new GenreDTO
                {
                    Id = x.Genre.Id,
                    Name = x.Genre.Name
                })
            };
        }
    }
}
