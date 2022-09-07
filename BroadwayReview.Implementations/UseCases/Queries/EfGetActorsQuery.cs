using BroadwayReview.Application.DTO;
using BroadwayReview.Application.DTO.Searches;
using BroadwayReview.Application.UseCases.Queries;
using BroadwayReview.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Implementations.UseCases.Queries
{
    public class EfGetActorsQuery : EFUseCaseConnection, IGetActorsQuery
    {
        public EfGetActorsQuery(BroadwayReviewContext context) : base(context)
        {
        }

        public int Id => 27;

        public string Name => "Use case for searching actors.";

        public string Description => "Use case for searching actors with EF.";

        public PagedResponse<GetActorDTO> Execute(BasePagedSearch request)
        {
            var actors = Context.Actors.Include(x => x.ActorPlays)
                .ThenInclude(x => x.Play).Where(x => x.IsActive).AsQueryable();
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                actors = actors.Where(x => x.Name.Contains(request.Keyword));
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
            var response = new PagedResponse<GetActorDTO>();
            response.TotalCount = actors.Count();
            response.ItemsPerPage = request.PerPage.Value;
            response.CurrentPage = request.Page.Value;
            response.Data = actors.Skip(toSkip.Value).Take(request.PerPage.Value).Select(x => new GetActorDTO
            {
                Id = x.Id,
                Name = x.Name,
                Plays = x.ActorPlays.Select(y => new PlayDTO
                {
                    Title = y.Play.Title
                })
            }).ToList();
            return response;
        }
    }
}
