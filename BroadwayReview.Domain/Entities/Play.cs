using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Domain.Entities
{
    public class Play : Entity
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public virtual ICollection<ActorPlay> ActorPlays { get; set; } = new List<ActorPlay>();
        public virtual ICollection<PlayGenre> PlayGenres { get; set; } = new List<PlayGenre>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
