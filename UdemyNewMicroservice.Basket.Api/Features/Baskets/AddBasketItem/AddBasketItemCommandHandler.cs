using System.Text.Json;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using UdemyNewMicroservice.Basket.Api.Const;
using UdemyNewMicroservice.Basket.Api.Dto;
using UdemyNewMicroservice.Shared;

namespace UdemyNewMicroservice.Basket.Api.Features.Baskets.AddBasketItem
{
    public class AddBasketItemCommandHandler(IDistributedCache distributedCache)
        : IRequestHandler<AddBasketItemCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(AddBasketItemCommand request, CancellationToken cancellationToken)
        {
            //Fast fail


            // TODO : change userId
            Guid userId = Guid.Parse("332ee8cd-f3f6-49fa-92e2-5fdb188b3377");
            var cacheKey = string.Format(BasketConst.BasketCacheKey, userId);

            var basketAsString = await distributedCache.GetStringAsync(cacheKey, token: cancellationToken);


            BasketDto? currentBasket;

            var newBasketItem = new BasketItemDto(request.CourseId, request.CourseName, request.ImageUrl,
                request.CoursePrice, null);


            if (string.IsNullOrEmpty(basketAsString))
            {
                currentBasket = new BasketDto(userId, [newBasketItem]);
                await CreateCacheAsync(currentBasket, cacheKey, cancellationToken);
                return ServiceResult.SuccessAsNoContent();
            }

            currentBasket = JsonSerializer.Deserialize<BasketDto>(basketAsString);


            var existingBasketItem = currentBasket!.BasketItems.FirstOrDefault(x => x.Id == request.CourseId);


            if (existingBasketItem is not null)
            {
                // TODO : business rule
                currentBasket.BasketItems.Remove(existingBasketItem);
            }

            currentBasket.BasketItems.Add(newBasketItem);

            await CreateCacheAsync(currentBasket, cacheKey, cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }

        private async Task CreateCacheAsync(BasketDto basket, string cacheKey, CancellationToken cancellationToken)
        {
            var basketAsString = JsonSerializer.Serialize(basket);
            await distributedCache.SetStringAsync(cacheKey, basketAsString, token: cancellationToken);
        }
    }
}