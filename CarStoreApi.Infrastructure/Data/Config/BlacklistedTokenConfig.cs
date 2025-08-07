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
    public class BlacklistedTokenConfig : IEntityTypeConfiguration<BlacklistedToken>
    {
        public void Configure(EntityTypeBuilder<BlacklistedToken> builder)
        {
           builder.HasKey(bt=> bt.Id);
            builder.Property(bt => bt.Token)
                    .IsRequired();
           builder.Property(bt=> bt.Id).ValueGeneratedOnAdd();
           builder.ToTable("BlacklistedToken");
        }
    }
  
}
