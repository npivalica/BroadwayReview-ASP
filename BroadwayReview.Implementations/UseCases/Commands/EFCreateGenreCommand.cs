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
    public class EFCreateGenreCommand : EFUseCaseConnection, ICreateGenreCommand
    {
        private readonly CreateGenreValidator _validator;
        public EFCreateGenreCommand(BroadwayReviewContext context, CreateGenreValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 6;

        public string Name => "Use case for creating a genre";

        public string Description => "Use case for creating a genre with EF";

        public void Execute(CreateGenreDTO request)
        {
            _validator.ValidateAndThrow(request);
            var genre = new Genre
            {
                Name = request.Name
            };
            Context.Genres.Add(genre);
            Context.SaveChanges();
        }
    }
}
