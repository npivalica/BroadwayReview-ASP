using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Application.DTO
{
    public class AuthorDTO : BaseDTO
    {
        public string Name { get; set; }
    }
    public class FindAuthorDTO
    {
        public string Name { get; set; }
        public IEnumerable<PlayDTO> Plays { get; set; }
    }
}
