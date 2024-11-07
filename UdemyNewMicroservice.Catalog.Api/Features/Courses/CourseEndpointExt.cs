using UdemyNewMicroservice.Catalog.Api.Features.Courses.Create;
using UdemyNewMicroservice.Catalog.Api.Features.Courses.Delete;
using UdemyNewMicroservice.Catalog.Api.Features.Courses.GetAll;
using UdemyNewMicroservice.Catalog.Api.Features.Courses.GetAllByUserId;
using UdemyNewMicroservice.Catalog.Api.Features.Courses.GetById;
using UdemyNewMicroservice.Catalog.Api.Features.Courses.Update;

namespace UdemyNewMicroservice.Catalog.Api.Features.Courses
{
    public static class CourseEndpointExt
    {
        public static void AddCourseGroupEndpointExt(this WebApplication app)
        {
            app.MapGroup("api/courses").WithTags("Courses")
                .CreateCourseGroupItemEndpoint()
                .GetAllCourseGroupItemEndpoint()
                .GetByIdCourseGroupItemEndpoint()
                .UpdateCourseGroupItemEndpoint()
                .DeleteCourseGroupItemEndpoint()
                .GetByUserIdCourseGroupItemEndpoint();
        }
    }
}