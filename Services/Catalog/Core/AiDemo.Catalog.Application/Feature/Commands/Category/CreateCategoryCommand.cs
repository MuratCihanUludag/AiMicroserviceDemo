using AiDemo.Catalog.Application.Feature.Response.Category;
using AiDemo.SharedLiblary.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiDemo.Catalog.Application.Feature.Commands.Category
{
    public record CreateCategoryCommand(string name,string description,string imageUrl) : IRequest<ServiceResult<CreateCategoryCommandResponse>>;
}
