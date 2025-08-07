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
    public class CarModelConfig : IEntityTypeConfiguration<CarModel>
    {
        public void Configure(EntityTypeBuilder<CarModel> builder)
        {
            builder.HasKey(m => m.CarId);
            builder.Property(m => m.CarId).ValueGeneratedOnAdd();
            builder.Property(m => m.ModelName).HasMaxLength(500).IsRequired();

            builder.HasOne(m => m.CarBrand).WithMany(b => b.CarModels).HasForeignKey(m => m.CarBrandId);

            builder.HasIndex(m => m.ModelName).IsUnique();

            builder.ToTable("CarModels");
        }
    }
}
