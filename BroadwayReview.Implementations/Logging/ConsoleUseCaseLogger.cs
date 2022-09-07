using BroadwayReview.Application.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Implementations.Logging
{
    public class ConsoleUseCaseLogger : IUseCaseLogger
    {
        public IEnumerable<UseCaseLog> GetLogs(UseCaseLogSearch log)
        {
            throw new NotImplementedException();
        }

        public void Log(UseCaseLog message)
        {
            Console.WriteLine($"UseCase: {message.UseCaseName}, User: {message.User}, {message.ExecutionDateTime}, Authorized: {message.IsAuthorized}");
            Console.WriteLine($"Use Case Data:  {message.Data}");
        }
    }
}
