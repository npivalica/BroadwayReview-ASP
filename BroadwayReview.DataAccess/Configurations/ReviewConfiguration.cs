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
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.Property(x => x.Text).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(70);
            builder.Property(x => x.PlayRating).IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Play)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.PlayId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
