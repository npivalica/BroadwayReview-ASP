using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Domain.Entities
{
    public class Genre : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<PlayGenre> GenrePlays { get; set; } = new List<PlayGenre>();
    }
}
