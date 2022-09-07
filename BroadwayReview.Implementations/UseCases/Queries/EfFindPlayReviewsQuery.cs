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
    public class EfFindPlayReviewsQuery : EFUseCaseConnection, IFindPlayReviewsQuery
    {
        public EfFindPlayReviewsQuery(BroadwayReviewContext context) : base(context)
        {
        }

        public int Id => 23;

        public string Name => "Use case for finding all reviews for a play.";

        public string Description => "Use case for finding all reviews for a play with EF.";

        public IEnumerable<GetReviewDTO> Execute(int request)
        {
            var play = Context.Plays.FirstOrDefault(x => x.Id == request);
            if (play == null)
            {
                throw new EntityNotFoundException(nameof(Play), request);
            }
            var reviews = Context.Reviews.Include(x => x.User)
                .Include(x => x.Play).Where(x => x.PlayId == request && x.IsActive);
            var response = reviews.Select(x => new GetReviewDTO
            {
                Title = x.Title,
                Text = x.Text,
                Date = x.CreatedAt,
                Play = x.Play.Title,
                User = x.User.Username
            });
            return response;
        }
    }
}
