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
    public class EFCreateReviewCommand : EFUseCaseConnection, ICreateReviewCommand
    {
        private IApplicationUser _user;
        private CreateReviewValidator _validator;
        public EFCreateReviewCommand(BroadwayReviewContext context, IApplicationUser user, CreateReviewValidator validator) : base(context)
        {
            _user = user;
            _validator = validator;
        }

        public int Id => 26;

        public string Name => "Use case for creating a review";

        public string Description => "Use case for creating a review with EF";

        public void Execute(ReviewDTO request)
        {
            _validator.ValidateAndThrow(request);
            if (_user.Id != request.UserId)
            {
                throw new ForbbidenUseCaseException(Name, _user.Email);
            }
            var review = new Review
            {
                Title = request.Title,
                Text = request.Text,
                PlayRating = request.PlayRating,
                UserId = request.UserId,
                PlayId = request.PlayId
            };
            Context.Reviews.Add(review);
            Context.SaveChanges();
        }
    }
}
