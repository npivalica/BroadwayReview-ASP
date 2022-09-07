using BroadwayReview.Application;
using System.Collections.Generic;

namespace BroadwayReview.Api.Auth
{
    public class AnonymousUser : IApplicationUser
    {
        public string Identity => "Anonymous";

        public int Id => 0;

        public string Email => "anon@asp.com";

        public IEnumerable<int> UseCaseIds => new List<int> { 3 };
    }
}
