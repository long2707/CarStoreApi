using CarStoreApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Infrastructure.Data.Config
{
    public class FeatureConfig : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.HasKey(f => f.FeatureId);
            builder.Property(f => f.FeatureId).ValueGeneratedOnAdd();
            builder.Property(f => f.FeatureName).HasMaxLength(256).IsRequired();
            builder.HasIndex(f => f.FeatureName).IsUnique();

            builder.ToTable("Features");
        }
    }
}
