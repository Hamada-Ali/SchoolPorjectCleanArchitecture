using SchoolProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Queries.Dto
{
    public class StudentDto
    {
       
        public int StudId { get; set; }
      
        public string? Name { get; set; }
      
        public string? Address { get; set; }
  
        public string? DepartmentName { get; set; }

    }
}
