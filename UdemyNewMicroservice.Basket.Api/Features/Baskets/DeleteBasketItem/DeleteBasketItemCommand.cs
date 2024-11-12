using UdemyNewMicroservice.Shared;

namespace UdemyNewMicroservice.Basket.Api.Features.Baskets.DeleteBasketItem
{
    public record DeleteBasketItemCommand(Guid CourseId) : IRequestByServiceResult;
}