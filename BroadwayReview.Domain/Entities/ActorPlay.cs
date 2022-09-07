using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Domain.Entities
{
    public class ActorPlay
    {
        public int Id { get; set; }

        public string CharacterName { get; set; }
        public int ActorId { get; set; }
        public int PlayId { get; set; }
        public virtual Actor Actor { get; set; }
        public virtual Play Play { get; set; }

    }
}
