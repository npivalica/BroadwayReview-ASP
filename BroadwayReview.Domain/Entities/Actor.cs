using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Domain.Entities
{
    public class Actor : Entity
    {
        public string Name { get; set; }
        public string ShortBio { get; set; }
        public virtual ICollection<ActorPlay> ActorPlays { get; set; } = new List<ActorPlay>();
    }
}
