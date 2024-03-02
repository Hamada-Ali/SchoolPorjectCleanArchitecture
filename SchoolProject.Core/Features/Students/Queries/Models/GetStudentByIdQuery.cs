using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.Dto;
using SchoolProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
    public class GetStudentByIdQuery : IRequest<ResponseInformation<StudentDto>>
    {
        public int Id { get; set; }

        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
