using BroadwayReview.Application.DTO;
using BroadwayReview.Application.Emails;
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
    public class EFRegisteUserCommand : EFUseCaseConnection, IRegisterUserCommand
    {
        private RegisterUserValidator _validator;
        private IEmailSender _sender;
        public EFRegisteUserCommand(BroadwayReviewContext context, RegisterUserValidator validator, IEmailSender sender) : base(context)
        {
            _validator = validator;
            _sender = sender;
        }

        public int Id => 4;

        public string Name => "Use case for registering an user.";

        public string Description => "Use case for registering an user with EF.";

        public void Execute(RegisterUserDTO request)
        {
            _validator.ValidateAndThrow(request);

            var user = new User
            {
                Username = request.Username,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
            };
            Context.Users.Add(user);
            Context.SaveChanges();
            //_sender.Send(new Email
            //{
            //    To = user.Email,
            //    Title = "Verify registration.",
            //    Body = ""
            //});

        }
    }
}
