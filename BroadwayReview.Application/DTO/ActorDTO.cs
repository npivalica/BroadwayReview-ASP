using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Application.DTO
{
    public class ActorDTO
    {
        public string Name { get; set; }

    }
    public class UpdateActorDTO : ActorDTO
    {
        public int Id { get; set; }
        public string ShortBio { get; set; }

    }
    public class GetActorDTO : UpdateActorDTO
    {
        public IEnumerable<PlayDTO> Plays { get; set; }
    }
}
