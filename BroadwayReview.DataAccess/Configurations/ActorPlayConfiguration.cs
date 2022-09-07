using BroadwayReview.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.DataAccess.Configurations
{
    public class ActorPlayConfiguration : IEntityTypeConfiguration<ActorPlay>
    {
        public void Configure(EntityTypeBuilder<ActorPlay> builder)
        {
            builder.Property(x => x.CharacterName).IsRequired().HasMaxLength(100);

            builder.HasAlternateKey(bc => new { bc.ActorId, bc.PlayId });
        }
    }
}
