using UdemyNewMicroservice.Catalog.Api.Features.Categories.Create;
using UdemyNewMicroservice.Catalog.Api.Features.Categories.GetAll;

namespace UdemyNewMicroservice.Catalog.Api.Features.Categories
{
    public static class CategoryEndpointExt
    {
        public static void AddCategoryGroupEndpointExt(this WebApplication app)
        {
            app.MapGroup("api/categories")
                .CreateCategoryGroupItemEndpoint()
                .GetAllCategoryGroupItemEndpoint();
        }
    }
}