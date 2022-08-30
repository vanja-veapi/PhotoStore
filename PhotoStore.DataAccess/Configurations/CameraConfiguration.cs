using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoAPI.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStore.DataAccess.Configurations
{
    public class CameraConfiguration : IEntityTypeConfiguration<Camera>
    {
        public void Configure(EntityTypeBuilder<Camera> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.BrandId).IsRequired();
            builder.Property(x => x.Image).HasMaxLength(300);
            builder.Property(x => x.Description).HasMaxLength(300);

            builder.HasIndex(x => x.Name);
        }
    }
}
