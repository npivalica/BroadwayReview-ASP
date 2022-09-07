﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BroadwayReview.Domain.Entities;

namespace BroadwayReview.DataAccess.Configurations
{
    public abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.DeletedBy).HasMaxLength(40).IsRequired(false);
            builder.Property(x => x.UpdatedBy).HasMaxLength(40).IsRequired(false);

            BaseConfiguring(builder);
        }

        public abstract void BaseConfiguring(EntityTypeBuilder<T> builder);
    }
}
