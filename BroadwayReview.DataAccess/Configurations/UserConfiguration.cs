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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.Username).IsRequired(true).HasMaxLength(20);
            builder.Property(x => x.Email).IsRequired(true).HasMaxLength(40);
            builder.Property(x => x.Password).IsRequired(true).HasMaxLength(80);

            builder.HasIndex(x => x.FirstName);
            builder.HasIndex(x => x.LastName);
            builder.HasIndex(x => x.Email).IsUnique(true);
            builder.HasIndex(x => x.Username).IsUnique(true);

            builder.HasMany(x => x.UserUseCases)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        }
    }
}
