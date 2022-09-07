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
    public class PlayConfiguration : EntityConfiguration<Play>
    {
        public override void BaseConfiguring(EntityTypeBuilder<Play> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(70);
            builder.Property(x => x.Year).IsRequired();

            builder.HasMany(x => x.ActorPlays)
                .WithOne(x => x.Play)
                .HasForeignKey(x => x.PlayId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.PlayGenres)
                .WithOne(x => x.Play)
                .HasForeignKey(x => x.PlayId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
