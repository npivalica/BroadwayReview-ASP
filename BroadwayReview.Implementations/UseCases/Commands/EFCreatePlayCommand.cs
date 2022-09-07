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
    public class EFCreatePlayCommand : EFUseCaseConnection, ICreatePlayCommand

    {
        private CreatePlayValidator _validator;
        public EFCreatePlayCommand(BroadwayReviewContext context, CreatePlayValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 17;

        public string Name => "Use case for creating a play";

        public string Description => "Use case for creating a play with EF";

        public void Execute(CreatePlayDTO request)
        {
            _validator.ValidateAndThrow(request);
            var play = new Play();

            play.Title = request.Title;
            play.Year = request.Year;
            play.Duration = request.Duration;
            play.Description = request.Description;
            play.AuthorId = request.AuthorId;
            play.PlayGenres = request.PlayGenreIds.Select(x => new PlayGenre
            {
                Play = play,
                GenreId = x
            }).ToList();

            Context.Plays.Add(play);
            Context.SaveChanges();

        }
    }
}
