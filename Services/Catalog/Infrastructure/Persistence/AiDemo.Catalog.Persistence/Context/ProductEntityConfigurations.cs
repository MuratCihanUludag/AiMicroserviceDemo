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
    public class ProductEntityConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToCollection("product");
            builder.Property(p => p.Id)
                   .HasElementName("_id")
                   .IsRequired();
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                   .ValueGeneratedNever();
            builder.Property(p => p.Name)
                   .HasElementName("name")
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(p => p.Description)
                   .HasElementName("description")
                   .IsRequired()
                   .HasMaxLength(500);
            builder.Property(p => p.Price)
                   .HasElementName("price")
                   .IsRequired();
            builder.Property(p => p.Stock)
                   .HasElementName("stock")
                   .IsRequired();
            builder.Property(p => p.CategoryId)
                   .HasElementName("categoryId")
                   .IsRequired(false);
            builder.Property(p => p.ImageUrl)
                   .HasElementName("imageUrl")
                   .IsRequired(false)
                   .HasMaxLength(200);
            builder.Property(p => p.CreatedAt)
                   .HasElementName("createdAt")
                   .IsRequired();
            builder.Property(p => p.UpdatedAt)
                   .HasElementName("updatedAt")
                   .IsRequired(false);
            builder.Ignore(p=>p.Category);

        }
    }
}
