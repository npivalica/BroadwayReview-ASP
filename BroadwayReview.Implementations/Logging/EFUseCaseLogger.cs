using BroadwayReview.Application.Logging;
using BroadwayReview.DataAccess;
using BroadwayReview.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Implementations.Logging
{
    public class EFUseCaseLogger : IUseCaseLogger
    {
        private BroadwayReviewContext _context;
        public EFUseCaseLogger(BroadwayReviewContext context)
        {
            _context = context;
        }
        public IEnumerable<UseCaseLog> GetLogs(UseCaseLogSearch log)
        {
            var logs = _context.UseCaseLogs.Where(x => x.ExecutionTime >= log.DateFrom && x.ExecutionTime <= log.DateTo).AsQueryable();
            if (!string.IsNullOrEmpty(log.UseCaseName))
            {
                logs = logs.Where(x => x.UseCaseName.Contains(log.UseCaseName));
            }
            if (!string.IsNullOrEmpty(log.UserName))
            {
                logs = logs.Where(x => x.Username.Contains(log.UserName));
            }
            if (log.UserId != null)
            {
                logs = logs.Where(x => x.UserId == log.UserId);
            }
            var response = logs.Select(x => new UseCaseLog
            {
                User = x.Username,
                UseCaseName = x.UseCaseName,
                Data = x.Data,
                UserId = x.UserId,
                ExecutionDateTime = x.ExecutionTime,
                IsAuthorized = x.IsAuthorized
            }).ToList();
            return response;
        }

        public void Log(UseCaseLog message)
        {
            var logRecord = new UseCaseLogger
            {
                UserId = message.UserId,
                Data = message.Data,
                ExecutionTime = DateTime.Now,
                IsAuthorized = message.IsAuthorized,
                UseCaseName = message.UseCaseName,
                Username = _context.Users.FirstOrDefault(x => x.Id == message.UserId).Username
            };
            _context.UseCaseLogs.Add(logRecord);
            _context.SaveChanges();
        }
    }
}
