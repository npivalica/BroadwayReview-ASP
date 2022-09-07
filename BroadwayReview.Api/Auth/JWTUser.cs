using BroadwayReview.Application;
using System.Collections.Generic;

namespace BroadwayReview.Api.Auth
{
    public class JWTUser : IApplicationUser
    {
        public string Identity { get; set; }

        public int Id { get; set; }

        public string Email { get; set; }

        public IEnumerable<int> UseCaseIds { get; set; } = new List<int> { };
    }
}
