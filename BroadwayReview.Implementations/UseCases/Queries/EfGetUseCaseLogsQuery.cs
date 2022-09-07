using BroadwayReview.Application.DTO;
using BroadwayReview.Application.DTO.Searches;
using BroadwayReview.Application.Logging;
using BroadwayReview.Application.UseCases.Queries;
using BroadwayReview.DataAccess;
using BroadwayReview.Implementations.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Implementations.UseCases.Queries
{
    public class EFGetUseCaseLogsQuery : IGetUseCaseLogsQuery
    {
        private readonly CreateUseCaseLogSearchValidator _validator;
        private readonly IUseCaseLogger _logger;

        public EFGetUseCaseLogsQuery(IUseCaseLogger logger, CreateUseCaseLogSearchValidator validator)
        {
            _logger = logger;
            _validator = validator;
        }

        public int Id => 31;

        public string Name => "Use case for searching use case logs";

        public string Description => "Use case for searching use case logs with EF";

        public IEnumerable<UseCaseLog> Execute(UseCaseLogSearch request)
        {
            _validator.ValidateAndThrow(request);
            return _logger.GetLogs(request);
        }
    }
}
