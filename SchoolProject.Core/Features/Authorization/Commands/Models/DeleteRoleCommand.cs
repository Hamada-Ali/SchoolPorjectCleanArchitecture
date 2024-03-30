﻿using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Authorization.Commands.Models
{
    public class DeleteRoleCommand : IRequest<ResponseInformation<string>>
    {
        public int Id { get; set; }

        public DeleteRoleCommand(int id)
        {
            Id = id;
        }
    }
}