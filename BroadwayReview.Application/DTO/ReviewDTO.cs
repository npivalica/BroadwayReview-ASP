using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Application.DTO
{
    public class ReviewDTO
    {
        public int UserId { get; set; }
        public int PlayId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int PlayRating { get; set; }

    }
    public class GetReviewDTO
    {
        public string User { get; set; }
        public string Play { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int PlayRating { get; set; }
        public DateTime Date { get; set; }

    }
}
