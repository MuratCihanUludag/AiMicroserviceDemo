using AiDemo.Catalog.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiDemo.Catalog.Persistence.Context
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToCollection("category");
            builder.Property(c => c.Id)
                   .HasElementName("_id")
                   .IsRequired();
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd();
            builder.Property(c => c.Name)
                   .HasElementName("name")
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(c => c.Description)
                   .HasElementName("description")
                   .IsRequired()
                   .HasMaxLength(500);
            builder.Property(c => c.ImageUrl)
                   .HasElementName("imageUrl");
            builder.Ignore(c => c.Products);
        }
    }
}
