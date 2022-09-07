using BroadwayReview.Application.Exceptions;
using BroadwayReview.Application.UseCases.Commands;
using BroadwayReview.DataAccess;
using BroadwayReview.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Implementations.UseCases.Commands
{
    public class EFDeleteReviewCommand : EFUseCaseConnection, IDeleteReviewCommand
    {
        public EFDeleteReviewCommand(BroadwayReviewContext context) : base(context)
        {
        }

        public int Id => 29;

        public string Name => "Use case for deleting a review on a play.";
        public string Description => "Use case for deleting a review on a play with EF.";

        public void Execute(int request)
        {
            var review = Context.Reviews.FirstOrDefault(x => x.Id == request && x.IsActive);
            if (review == null)
            {
                throw new EntityNotFoundException(nameof(Review), request);
            }
            Context.Reviews.Remove(review);
            Context.SaveChanges();
        }
    }
}
