using AiDemo.Catalog.Application.Feature.Queries.Category;
using AiDemo.Catalog.Application.Feature.Response.Category;
using AiDemo.SharedLiblary.GenaricRepositories.Abstractions;
using AiDemo.SharedLiblary.Result;
using MediatR;

namespace AiDemo.Catalog.Application.Feature.Handlers.Catalog
{
    public class GetAllCatalogQueryHandler(IReadGenaricRepository<Domain.Aggregates.Category, int> _categoryRepository) : IRequestHandler<GetAllCategoryQuery, ServiceResult<IList<GetAllCategoryQueryResponse>>>
    {
        public async Task<ServiceResult<IList<GetAllCategoryQueryResponse>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categoryList = await _categoryRepository.GetAllAsync();
            var categoryResponseList = categoryList.Select(c => new GetAllCategoryQueryResponse(c.Name, c.Description, c.ImageUrl!, c.Id)).ToList();
            return ServiceResult<IList<GetAllCategoryQueryResponse>>.Success(categoryResponseList);
        }
    }
}
