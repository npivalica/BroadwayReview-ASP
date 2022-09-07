using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BroadwayReview.Api.Extensions
{
    public static class ValidationExtensions
    {
        public static UnprocessableEntityObjectResult ToUnprocessableEntity(this IEnumerable<ValidationFailure> errors)
        {
            var errorMsgs = errors.Select(x => new
            {
                errorMessge = x.ErrorMessage,
                errorName = x.PropertyName
            });
            return new UnprocessableEntityObjectResult(errorMsgs);

        }
    }
}
