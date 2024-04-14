using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entities;
using SchoolProject.Infrustructure.Interface;
using SchoolProject.Services.Interface;

namespace SchoolProject.Services.Implementation
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstrctorRespository _instrctorRespository;
        private readonly IFileService _fileService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InstructorService(IInstrctorRespository instrctorRespository, IFileService fileService,
                                    IHttpContextAccessor httpContextAccessor)
        {
            _instrctorRespository = instrctorRespository;
            _fileService = fileService;
            _httpContextAccessor = httpContextAccessor;
        }



        public async Task<bool> IsNameExistAr(string name)
        {
            var ins = await _instrctorRespository.GetTableNoTracking().Where(x => x.ENameAr == name).FirstOrDefaultAsync();

            if (ins != null)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> IsNameExistEn(string name)
        {
            var ins = await _instrctorRespository.GetTableNoTracking().Where(x => x.ENameEn == name).FirstOrDefaultAsync();

            if (ins != null)
            {
                return true;
            }

            return false;
        }

        public async Task<string> AddInstructorAsync(Instructor instructor, IFormFile file)
        {

            var context = _httpContextAccessor.HttpContext.Request;
            var baseurl = context.Scheme + "://" + context.Host;
            var ImageUrl = await _fileService.UploadImage("Instructor", file);

            if (ImageUrl == "NoImage") { return "NoImage"; }
            if (ImageUrl == "Failed to Upload") { return "FailedToUpload"; }

            instructor.Image = baseurl + ImageUrl;

            try
            {

                var result = await _instrctorRespository.AddAsync(instructor);
                return "Success";
            }
            catch (Exception ex)
            {
                return "FailedInAdd";
            }



        }
    }
}
