using Amazon.Runtime.Internal;
using MediatR;
using UdemyNewMicroservice.Shared;

namespace UdemyNewMicroservice.Catalog.Api.Features.Categories.Create
{
    public record CreateCategoryCommand(string Name) : IRequest<ServiceResult<CreateCategoryResponse>>;
}