using Asp.Versioning.Builder;


namespace UdemyNewMicroservice.Catalog.Api.Features.Courses
{
    public static class FileEndpointExt
    {
        public static void AddDiscountGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/files").WithTags("files").WithApiVersionSet(apiVersionSet)
                ;
        }
    }
}