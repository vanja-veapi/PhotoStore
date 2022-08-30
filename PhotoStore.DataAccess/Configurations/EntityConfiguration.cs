using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStore.DataAccess.Configurations
{
    public abstract class EntityConfiguration : IEntityTypeConfiguration<Entity>
    {
        public void Configure(EntityTypeBuilder<Entity> builder)
        {
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.UpdatedBy).HasMaxLength(50);
            builder.Property(x => x.DeletedBy).HasMaxLength(50);

            //builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");

            ConfigureRules(builder);
        }

        protected abstract void ConfigureRules(EntityTypeBuilder<Entity> builder);
    }
}
