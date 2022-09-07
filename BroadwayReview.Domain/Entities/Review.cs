using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Domain.Entities
{
    public class Review : Entity
    {
        public int UserId { get; set; }
        public int PlayId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int PlayRating { get; set; }
        public virtual User User { get; set; }
        public virtual Play Play { get; set; }
    }
}
