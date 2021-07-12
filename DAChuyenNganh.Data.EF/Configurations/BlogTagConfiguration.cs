using DAChuyenNganh.Data.EF.Extensions;
using DAChuyenNganh.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAChuyenNganh.Data.EF.Configurations
{
    public class BlogTagConfiguration : DbEntityConfiguration<BlogTag>
    {
        public override void Configure(EntityTypeBuilder<BlogTag> entity)
        {
            //entity.Property(c => c.TagId).HasMaxLength(50).IsRequired()
            //.HasColumnType("varchar(50)");
            entity.Property(c => c.TagId).HasMaxLength(50).IsRequired()
            .IsUnicode(false).HasMaxLength(50);
            // etc.
        }
    }
}
