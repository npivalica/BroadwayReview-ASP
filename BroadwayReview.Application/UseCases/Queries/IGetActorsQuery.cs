using BroadwayReview.Application.DTO;
using BroadwayReview.Application.DTO.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Application.UseCases.Queries
{
    public interface IGetActorsQuery : IQuery<BasePagedSearch, PagedResponse<GetActorDTO>>
    {
    }
}
