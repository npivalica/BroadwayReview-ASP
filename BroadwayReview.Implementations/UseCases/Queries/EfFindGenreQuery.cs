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
    public class EfFindGenreQuery : EFUseCaseConnection, IFindGenreQuery
    {
        public EfFindGenreQuery(BroadwayReviewContext context) : base(context)
        {
        }

        public int Id => 14;

        public string Name => "Use case for finding genres.";

        public string Description => "Use case for finding genres with EF.";

        public FindGenreDTO Execute(int request)
        {
            var genre = Context.Genres.Include(x => x.GenrePlays)
                .ThenInclude(x => x.Genre).FirstOrDefault(x => x.Id == request && x.IsActive);
            if (genre == null)
            {
                throw new EntityNotFoundException(nameof(Genre), request);
            }
            return new FindGenreDTO
            {
                Name = genre.Name,
                Plays = genre.GenrePlays.Select(x => new PlayDTO
                {
                    Title = x.Play.Title,
                    Year = x.Play.Year,
                    Duration = x.Play.Duration

                })
            };
        }
    }
}
