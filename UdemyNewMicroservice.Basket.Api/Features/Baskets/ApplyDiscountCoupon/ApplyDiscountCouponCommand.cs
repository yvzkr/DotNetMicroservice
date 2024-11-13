using UdemyNewMicroservice.Shared;

namespace UdemyNewMicroservice.Basket.Api.Features.Baskets.ApplyDiscountCoupon
{
    public record ApplyDiscountCouponCommand(string Coupon, float DiscountRate) : IRequestByServiceResult;
}