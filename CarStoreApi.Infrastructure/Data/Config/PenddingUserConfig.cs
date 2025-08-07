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
    public class PenddingUserConfig : IEntityTypeConfiguration<PenddingUser>
    {
        public void Configure(EntityTypeBuilder<PenddingUser> builder)
        {
            builder.HasKey(pu => pu.Id);
            builder.Property(pu => pu.Id).ValueGeneratedOnAdd();
            builder.Property(u => u.Name).HasMaxLength(150).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(150).IsRequired();
            builder.Property(u => u.Phone).HasMaxLength(20).IsRequired(false);

            builder.HasIndex(u => u.Email).IsUnique();
            builder.HasIndex(u => u.Phone).IsUnique();

            builder.ToTable("PenddingUsers");
        }
    }
}
