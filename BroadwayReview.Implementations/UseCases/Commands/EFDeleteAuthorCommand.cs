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
    public class EFDeleteAuthorCommand : EFUseCaseConnection, IDeleteAuthorCommand
    {
        public EFDeleteAuthorCommand(BroadwayReviewContext context) : base(context)
        {
        }

        public int Id => 5;

        public string Name => "Use case for deleting an author.";

        public string Description => "Use case for deleting a author with EF.";

        public void Execute(int request)
        {
            var author = Context.Authors.Include(x => x.Plays).FirstOrDefault(x => x.Id == request && x.IsActive);
            if (author == null)
            {
                throw new EntityNotFoundException(nameof(Author), request);
            }
            if (author.Plays.Any())
            {
                throw new UseCaseConflictException("Deleting the author was denied because it contains plays that reference to it: " +
                    string.Join(", ", author.Plays.Select(x => x.Title)));
            }
            author.DeletedAt = DateTime.Now;
            author.IsActive = false;

            Context.SaveChanges();

        }
    }
}
