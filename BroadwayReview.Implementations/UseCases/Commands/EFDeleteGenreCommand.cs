using BroadwayReview.Application.Exceptions;
using BroadwayReview.Application.UseCases.Commands;
using BroadwayReview.DataAccess;
using BroadwayReview.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Implementations.UseCases.Commands
{
    public class EFDeleteGenreCommand : EFUseCaseConnection, IDeleteGenreCommand
    {
        public EFDeleteGenreCommand(BroadwayReviewContext context) : base(context)
        {
        }

        public int Id => 4;

        public string Name => "Use case for deleting a genre.";

        public string Description => "Use case for deleting a genre with EF.";

        public void Execute(int request)
        {
            var genre = Context.Genres.Include(x => x.GenrePlays).FirstOrDefault(x => x.Id == request && x.IsActive);
            if (genre == null)
            {
                throw new EntityNotFoundException(nameof(Genre), request);
            }
            if (genre.GenrePlays.Any())
            {
                throw new UseCaseConflictException("You cannot delete genre because it has plays related to it.");
            }
            genre.IsActive = false;
            genre.DeletedAt = DateTime.Now;
            Context.SaveChanges();
        }
    }
}
