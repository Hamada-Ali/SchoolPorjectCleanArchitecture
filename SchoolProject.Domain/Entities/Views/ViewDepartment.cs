using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Common;

namespace SchoolProject.Domain.Entities.Views
{
    // view structure
    [Keyless] // this mean you don't have key  
    public class ViewDepartment : GeneralLocalizableEntity
    {
        public int DID { get; set; }
        public string? DNameAr { get; set; }
        public string? DNameEn { get; set; }
        public int StudentCount { get; set; }
    }
}
