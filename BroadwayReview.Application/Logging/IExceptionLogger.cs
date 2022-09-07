using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Application.Logging
{
    public interface IExceptionLogger
    {
        public void LogException(Exception exception);
    }
}
