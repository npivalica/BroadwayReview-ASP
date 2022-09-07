using BroadwayReview.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Implementations.UseCases
{
    public abstract class EFUseCaseConnection
    {
        protected BroadwayReviewContext Context;
        public EFUseCaseConnection(BroadwayReviewContext context)
        {
            Context = context;
        }
    }
}
