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
    public class EFUpdateUserUseCases : EFUseCaseConnection, IUpdateUserUseCaseCommand
    {
        private UpdateUserUseCaseValidator _validator;
        public EFUpdateUserUseCases(BroadwayReviewContext context, UpdateUserUseCaseValidator validator)
            : base(context)
        {
            _validator = validator;
        }
        public int Id => 5;

        public string Name => "Use case for registering an user.";

        public string Description => "Use case for registering an user with EF.";

        public void Execute(UpdateUserUseCaseDTO request)
        {
            _validator.ValidateAndThrow(request);
            var userUseCases = Context.UserUseCases.Where(x => x.UserId == request.UserId);
            Context.UserUseCases.RemoveRange(userUseCases);
            var newUserUseCases = request.UseCaseIds.Select(x => new UserUseCase
            {
                UserId = request.UserId,
                UseCaseId = x
            });
            Context.UserUseCases.AddRange(newUserUseCases);
            Context.SaveChanges();
        }
    }
}
