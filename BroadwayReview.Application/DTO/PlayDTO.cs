using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Application.DTO
{
    public class PlayDTO
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public int Duration { get; set; }


    }
    public class ExtendedPlayDTO : PlayDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public IEnumerable<GenreDTO> Genres { get; set; }
    }
    public class CreatePlayDTO : PlayDTO
    {
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public IEnumerable<int> PlayGenreIds { get; set; }
    }
    public class UpdatePlayDTO : CreatePlayDTO
    {
        public int Id { get; set; }

    }
}
