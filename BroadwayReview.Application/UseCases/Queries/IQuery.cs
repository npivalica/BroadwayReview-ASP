using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Application.UseCases.Queries
{
    public interface IQuery<TRequest, TResponse> : IUseCase
    {
        public TResponse Execute(TRequest request);
    }
}
