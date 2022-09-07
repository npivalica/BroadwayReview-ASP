using BroadwayReview.Application.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Implementations.Logging
{
    public class ConsoleExceptionLogger : IExceptionLogger
    {
        public void LogException(Exception exception)
        {
            Console.WriteLine("Exception occured at " + DateTime.UtcNow);
            Console.WriteLine(exception.Message);
            Console.WriteLine(exception.InnerException);
        }
    }
}
