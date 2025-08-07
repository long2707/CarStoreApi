using CarStoreApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Infrastructure.Data.Config
{
    public class CarBrandConfig :IEntityTypeConfiguration<CarBrand>
    {
        public void Configure(EntityTypeBuilder<CarBrand> builder)
        {
            builder.HasKey(b => b.BrandId);
            builder.Property(b => b.BrandId).ValueGeneratedOnAdd();
            builder.Property(b => b.BrandName).HasMaxLength(256).IsRequired();
            builder.Property(b => b.Logo).HasMaxLength(256);

            builder.HasIndex(b => b.BrandName).IsUnique();

            builder.ToTable("CarBrands");
        }
    }
}
