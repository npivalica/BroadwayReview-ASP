using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Application.DTO
{
    public class GenreDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
    }
    public class CreateGenreDTO : GenreDTO
    {
       
    }
    public class FindGenreDTO : CreateGenreDTO
    {
        public IEnumerable<PlayDTO> Plays { get; set; }
    }
}
