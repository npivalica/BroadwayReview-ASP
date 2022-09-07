using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Domain.Entities
{
    public class PlayGenre
    {
        public int PlayId { get; set; }
        public int GenreId { get; set; }
        public virtual Play Play { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
