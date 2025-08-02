using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiDemo.Catalog.Application.Feature.Response.Category
{
    public record CreateCategoryCommandResponse(int id,string name, string description, string? imageUrl);
}
