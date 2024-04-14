using MediatR;
using Microsoft.AspNetCore.Http;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Instructors.command.Models
{
    public class AddInstructorCommand : IRequest<ResponseInformation<string>>
    {
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public string? Address { get; set; }
        public string? Position { get; set; }
        public int? SupervisorId { get; set; }
        public decimal? Salary { get; set; }
        public int DID { get; set; }
        public IFormFile? Image { get; set; }
    }
}
