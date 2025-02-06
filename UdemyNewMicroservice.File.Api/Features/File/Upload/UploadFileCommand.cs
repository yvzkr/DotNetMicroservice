using UdemyNewMicroservice.Shared;

namespace UdemyNewMicroservice.File.Api.Features.File.Upload
{
    public record UploadFileCommand(IFormFile File) : IRequestByServiceResult<UploadFileCommandResponse>;
}