using BroadwayReview.Application;
using BroadwayReview.Application.Exceptions;
using BroadwayReview.Application.Logging;
using BroadwayReview.Application.UseCases.Commands;
using BroadwayReview.Application.UseCases.Queries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Implementations.UseCases
{
    public class UseCaseHandler
    {
        private IExceptionLogger _exceptionLogger;
        private IUseCaseLogger _useCaseLogger;
        private IApplicationUser _user;
        public UseCaseHandler(IExceptionLogger logger, IUseCaseLogger useCaseLogger, IApplicationUser user)
        {
            _exceptionLogger = logger;
            _useCaseLogger = useCaseLogger;
            _user = user;
        }
        private void LogAndAuthorize<TRequest>(IUseCase usecase, TRequest data)
        {
            var isAuthorized = _user.UseCaseIds.Contains(usecase.Id);
            var log = new UseCaseLog
            {
                User = _user.Identity,
                UseCaseName = usecase.Name,
                ExecutionDateTime = DateTime.Now,
                UserId = _user.Id,
                Data = JsonConvert.SerializeObject(data),

                IsAuthorized = isAuthorized

            };
            _useCaseLogger.Log(log);
            if (!log.IsAuthorized)
            {
                throw new ForbbidenUseCaseException(usecase.Name, _user.Email);
            }
        }
        public void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data)
        {
            try
            {
                LogAndAuthorize(command, data);
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                command.Execute(data);
                stopwatch.Stop();
                Console.WriteLine(command.Name + " Duration: " + stopwatch.ElapsedMilliseconds + " ms.");
            }
            catch (Exception ex)
            {
                _exceptionLogger.LogException(ex);
                throw;
            }
        }
        public TResponse HandleQuery<TRequest, TResponse>(IQuery<TRequest, TResponse> query, TRequest data)
        {
            try
            {
                LogAndAuthorize(query, data);
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var result = query.Execute(data);

                stopwatch.Stop();
                Console.WriteLine(query.Name + " Duration: " + stopwatch.ElapsedMilliseconds + " ms.");
                return result;
            }
            catch (Exception ex)
            {
                _exceptionLogger.LogException(ex);
                throw;
            }
        }
    }
}
