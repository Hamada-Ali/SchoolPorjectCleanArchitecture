using Microsoft.AspNetCore.Http;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Services.Interface
{
    public interface IInstructorService
    {
        public Task<bool> IsNameExistAr(string name);
        public Task<bool> IsNameExistEn(string name);
        public Task<string> AddInstructorAsync(Instructor instructor, IFormFile file);
    }
}
