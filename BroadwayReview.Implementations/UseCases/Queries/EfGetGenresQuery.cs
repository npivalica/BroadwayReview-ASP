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
    public class EfGetGenresQuery : EFUseCaseConnection, IGetGenresQuery
    {
        public EfGetGenresQuery(BroadwayReviewContext context) : base(context)
        {
        }

        public int Id => 12;

        public string Name => "Use case for searching genres";

        public string Description => "Use case for searching genres with EF";

        public PagedResponse<GenreDTO> Execute(BasePagedSearch request)
        {
            var query = Context.Genres.Where(x => x.IsActive).AsQueryable();
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Name.Contains(request.Keyword));
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
            var response = new PagedResponse<GenreDTO>();
            response.TotalCount = query.Count();
            response.ItemsPerPage = request.PerPage.Value;
            response.CurrentPage = request.Page.Value;
            response.Data = query.Skip(toSkip.Value).Take(request.PerPage.Value).Select(x => new GenreDTO
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
            return response;
        }
    }
}
