using Asp.Versioning.Builder;
using UdemyNewMicroservice.Discount.Api.Features.Discounts.CreateDiscount;
using UdemyNewMicroservice.File.Api.Features.File.Delete;


namespace UdemyNewMicroservice.Catalog.Api.Features.Courses
{
    public static class FileEndpointExt
    {
        public static void AddFileGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/files").WithTags("files").WithApiVersionSet(apiVersionSet).UploadFileGroupItemEndpoint().DeleteFileGroupItemEndpoint();
        }
    }
}