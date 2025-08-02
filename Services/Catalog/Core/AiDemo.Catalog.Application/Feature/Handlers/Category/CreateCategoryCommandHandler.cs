using AiDemo.Catalog.Application.Feature.Commands.Category;
using AiDemo.Catalog.Application.Feature.Response.Category;
using AiDemo.SharedLiblary.GenaricRepositories.Abstractions;
using AiDemo.SharedLiblary.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiDemo.Catalog.Application.Feature.Handlers.Category
{
    public class CreateCategoryCommandHandler
        (IWriteGenaricRepository<Domain.Aggregates.Category, int> _genaricRepository) : IRequestHandler<CreateCategoryCommand, ServiceResult<CreateCategoryCommandResponse>>
    {
        public async Task<ServiceResult<CreateCategoryCommandResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Domain.Aggregates.Category(request.name, request.description, request.imageUrl);
            var result =  await _genaricRepository.AddAsync(category);
            var response = new CreateCategoryCommandResponse(result.Id, result.Name, result.Description, result.ImageUrl);  
            return ServiceResult<CreateCategoryCommandResponse>.SuccessAsNoContent(response,"");
        }
    }
}
