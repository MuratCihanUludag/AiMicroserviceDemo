using AiDemo.SharedLiblary.Domain;
using ClassLibrary1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiDemo.Catalog.Domain.Aggregates
{
    public class Category : AggregateRoot<int>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string? ImageUrl { get; private set; } = "noimage.png";
        public Category() { }
        public Category(string name, string description,string? imageUrl = null)
        {
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
        }
        public Category(int id,string name, string description, string? imageUrl = null) : this(string.Empty, string.Empty, null)
        {
            Id = id;
        }

        public IQueryable<Product> Products { get; set; }

    }
}
