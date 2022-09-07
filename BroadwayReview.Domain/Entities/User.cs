using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Domain.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string FirstLastUsername => $"{FirstName}{LastName}{Username}";
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<UserUseCase> UserUseCases { get; set; } = new List<UserUseCase>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        public virtual ICollection<UseCaseLogger> UseCaseLogs { get; set; } = new List<UseCaseLogger>();

    }
}
