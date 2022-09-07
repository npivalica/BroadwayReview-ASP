using BroadwayReview.Application.DTO;
using BroadwayReview.Application.DTO.Searches;
using BroadwayReview.Application.UseCases.Queries;
using BroadwayReview.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Implementations.UseCases.Queries
{
    public class EfGetAuthorsQuery : EFUseCaseConnection, IGetAuthorsQuery
    {
        public EfGetAuthorsQuery(BroadwayReviewContext context) : base(context)
        {
        }

        public int Id => 1;

        public string Name => "Use case for searching authors";

        public string Description => "Use case for searching authors with EF";

        public PagedResponse<AuthorDTO> Execute(BasePagedSearch request)
        {

            var query = Context.Authors.Where(x => x.IsActive).AsQueryable();
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
            var response = new PagedResponse<AuthorDTO>();
            response.CurrentPage = request.Page.Value;
            response.ItemsPerPage = request.PerPage.Value;
            response.TotalCount = query.Count();
            response.Data = query.Skip(toSkip.Value).Take(request.PerPage.Value).Select(x => new AuthorDTO
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return response;
        }
    }
}
