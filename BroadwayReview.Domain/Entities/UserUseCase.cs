using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Domain.Entities
{
    public class UserUseCase
    {
        public int UseCaseId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
