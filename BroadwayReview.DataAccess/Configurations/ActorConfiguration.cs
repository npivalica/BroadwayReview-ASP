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
    public class ActorConfiguration : EntityConfiguration<Actor>
    {
        public override void BaseConfiguring(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(80);
            builder.HasIndex(x => x.Name).IsUnique(true);

            builder.HasMany(x => x.ActorPlays)
                .WithOne(x => x.Actor)
                .HasForeignKey(x => x.ActorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
