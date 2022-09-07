using BroadwayReview.Application.DTO;
using BroadwayReview.Application.DTO.Searches;
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
    public class EfGetPlaysQuery : EFUseCaseConnection, IGetPlaysQuery
    {
        public EfGetPlaysQuery(BroadwayReviewContext context) : base(context)
        {
        }

        public int Id => 13;

        public string Name => "Use case for searching plays";

        public string Description => "Use case for searching plays with EF";

        public PagedResponse<ExtendedPlayDTO> Execute(BasePagedSearch request)
        {
            var query = Context.Plays.Include(x => x.Author)
                .Include(x => x.PlayGenres).ThenInclude(x => x.Genre)
                .Where(x => x.IsActive).AsQueryable();
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Title.Contains(request.Keyword) 
                || x.Author.Name.Contains(request.Keyword) 
                || x.Description.Contains(request.Keyword));
            }
            if (request.PerPage == null || request.PerPage < 10)
            {
                request.PerPage = 10;
            }
            if (request.Page == null || request.Page < 1)
            {
                request.Page = 1;
            }
            var toSkip = (request.Page - 1) * request.PerPage;
            var response = new PagedResponse<ExtendedPlayDTO>
            {
                TotalCount = query.Count(),
                CurrentPage = request.Page.Value,
                ItemsPerPage = request.PerPage.Value,
                Data = query.Skip(toSkip.Value).Take(request.PerPage.Value).Select(x => new ExtendedPlayDTO
                {
                    Id = x.Id,
                    Title = x.Title,
                    Year = x.Year,
                    Duration = x.Duration,
                    Description = x.Description,
                    Author = x.Author.Name,
                    Genres = x.PlayGenres.Select(y => new GenreDTO
                    {
                        Id = y.Genre.Id,
                        Name = y.Genre.Name
                    })
                })
            };
            return response;
        }
    }
}
