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
    public class EFUpdatePlayCommand : EFUseCaseConnection, IUpdatePlayCommand
    {
        private readonly UpdatePlayValidator _validator;

        public EFUpdatePlayCommand(BroadwayReviewContext context, UpdatePlayValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 17;

        public string Name => "Use case for updating a play.";

        public string Description => "Use case for updating a play with EF.";

        public void Execute(UpdatePlayDTO request)
        {
            _validator.ValidateAndThrow(request);
            var play = Context.Plays.FirstOrDefault(x => x.Id == request.Id && x.IsActive);
            if (play == null)
            {
                throw new EntityNotFoundException(nameof(Play), (int)request.Id);

            }
            play.Title = request.Title;
            play.Year = request.Year;
            play.Duration = request.Duration;
            play.Description = request.Description;
            play.AuthorId = request.AuthorId;
            var playGenre = Context.PlayGenres.Where(x => x.PlayId == play.Id);
            Context.PlayGenres.RemoveRange(playGenre);
            play.PlayGenres = request.PlayGenreIds.Select(x => new PlayGenre
            {
                Play = play,
                GenreId = x
            }).ToList();
            Context.SaveChanges();
        }
    }
}
