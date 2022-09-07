using BroadwayReview.Application.DTO;
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
    public class EFCreateAuthorCommand : EFUseCaseConnection, ICreateAuthorCommand
    {
        private CreateAuthorValidator _validator;
        public int Id => 3;
        public string Name => "Use case for creating authors.";
        public string Description => "Use case for creating authors with EF";
        public EFCreateAuthorCommand(BroadwayReviewContext context, CreateAuthorValidator validator) : base(context)
        {
            _validator = validator;
        }
        public void Execute(AuthorDTO request)
        {
            _validator.ValidateAndThrow(request);

            var author = new Author
            {
                Name = request.Name

            };
            Context.Add(author);
            Context.SaveChanges();
        }
    }
}
