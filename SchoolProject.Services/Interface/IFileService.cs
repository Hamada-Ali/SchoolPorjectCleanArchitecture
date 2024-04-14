using Microsoft.AspNetCore.Http;

namespace SchoolProject.Services.Interface
{
    public interface IFileService
    {
        public Task<string> UploadImage(string Location, IFormFile file);
    }
}
