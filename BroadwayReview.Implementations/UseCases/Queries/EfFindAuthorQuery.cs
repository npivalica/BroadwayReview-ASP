using BroadwayReview.Application.DTO;
using BroadwayReview.Application.Exceptions;
using BroadwayReview.Application.UseCases.Queries;
using BroadwayReview.DataAccess;
using BroadwayReview.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Implementations.UseCases.Queries
{
    public class EfFindAuthorQuery : EFUseCaseConnection, IFindAuthorQuery
    {
        public EfFindAuthorQuery(BroadwayReviewContext context) : base(context)
        {
        }

        public int Id => 9;

        public string Name => "Use case for finding authors.";

        public string Description => "Use case for finding authors using EF.";

        public FindAuthorDTO Execute(int request)
        {
            var author = Context.Authors.Include(x => x.Plays)
                            .FirstOrDefault(x => x.Id == request && x.IsActive);
            if (author == null)
            {
                throw new EntityNotFoundException(nameof(Author), request);
            }
            return new FindAuthorDTO
            {
                Name = author.Name,
                Plays = author.Plays.Select(x => new PlayDTO
                {
                    Title = x.Title,
                    Year = x.Year,
                    Duration = x.Duration
                })
            };
        }
    }
}
