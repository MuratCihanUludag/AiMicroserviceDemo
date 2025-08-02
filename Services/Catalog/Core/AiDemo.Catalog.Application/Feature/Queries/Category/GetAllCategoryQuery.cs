using AiDemo.Catalog.Application.Feature.Response.Category;
using AiDemo.SharedLiblary.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiDemo.Catalog.Application.Feature.Queries.Category
{
    public record GetAllCategoryQuery() : IRequest<ServiceResult<IList<GetAllCategoryQueryResponse>>>;
   
}
