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
    public class EFUpdateGenreCommand : EFUseCaseConnection, IUpdateGenreCommand
    {
        private readonly UpdateGenreValidator _validator;
        public EFUpdateGenreCommand(BroadwayReviewContext context, UpdateGenreValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 11;

        public string Name => "Use case for updating a genre.";

        public string Description => "Use case for updating a genre with EF.";

        public void Execute(CreateGenreDTO request)
        {
            _validator.ValidateAndThrow(request);
            var genre = Context.Genres.FirstOrDefault(x => x.Id == request.Id && x.IsActive);
            if (genre == null)
            {
                throw new EntityNotFoundException(nameof(Genre), (int)request.Id);

            }
            genre.Name = request.Name;
            Context.SaveChanges();
        }
    }
}
