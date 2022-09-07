using BroadwayReview.Application.DTO;
using BroadwayReview.Application.UseCases.Commands;
using BroadwayReview.DataAccess;
using BroadwayReview.Implementations.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Implementations.UseCases.Commands
{
    public class EFUpdateAuthorCommand : EFUseCaseConnection, IUpdateAuthorCommand
    {
        private UpdateAuthorValidator _validator;

        public EFUpdateAuthorCommand(BroadwayReviewContext context, UpdateAuthorValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 7;

        public string Name => "Use case for updating an author.";

        public string Description => "Use case for updating an author with EF.";

        public void Execute(AuthorDTO request)
        {
            _validator.ValidateAndThrow(request);
            var author = Context.Authors.FirstOrDefault(x => x.Id == request.Id);
            author.Name = request.Name;

            Context.SaveChanges();
        }
    }
}
