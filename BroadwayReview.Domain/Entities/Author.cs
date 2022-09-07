﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Domain.Entities
{
    public class Author : Entity
    {
        public string Name { get; set; }
        public ICollection<Play> Plays { get; set; }
    }
}
