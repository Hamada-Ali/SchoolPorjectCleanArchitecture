using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Localization;
using Moq;
using SchoolProject.Core.Features.Students.Commands.Handlers;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Mapping.Students;
using SchoolProject.Core.Resources;
using SchoolProject.Domain.Entities;
using SchoolProject.Services.Interface;
using System.Net;

namespace SchoolProject.XUnit.Test.CoreTest.Students.Commands
{
    public class StudentCommandHandlerTest
    {
        private readonly Mock<IStudentService> _studentServiceMock;
        private readonly IMapper _imapperMock;
        private readonly Mock<IStringLocalizer<SharedResources>> _stringLocalizerMock;
        private readonly StudentProfile _studentProfile;
        public StudentCommandHandlerTest()
        {
            _studentProfile = new StudentProfile();
            _studentServiceMock = new Mock<IStudentService>();
            //_imapperMock = new();
            _stringLocalizerMock = new();
            var configration = new MapperConfiguration(c => c.AddProfile(_studentProfile));
            _imapperMock = new Mapper(configration);
        }
        [Fact]
        public async Task Handle_AddStudent_Should_Add_Data_and_201()
        {
            // Arrage
            var handler = new StudentCommandHandler(_studentServiceMock.Object, _imapperMock, _stringLocalizerMock.Object);
            // var department = new Department() { DNameAr = "هندسة", DNameEn = "engineering" };
            // var student = new Student() { NameAr = "محمد", NameEn = "Mohamed", DID = 1 };
            var addStudnetCommand = new AddStudentCommand() { NameAr = "محمد", NameEn = "Mohamed", Phone = "01043242", DepartmentId = 1 };

            _studentServiceMock.Setup(x => x.AddAsync(It.IsAny<Student>())).Returns(Task.FromResult("Success"));
            //Act
            var result = await handler.Handle(addStudnetCommand, default);
            // Assert'

            result.StatusCode.Should().Be(HttpStatusCode.Created);
            result.Succeeded.Should().BeTrue();
            _studentServiceMock.Verify(x => x.AddAsync(It.IsAny<Student>()), Times.Once, "Failed to excute");

            // verfiy how much it called the metod ex ( adding studnet 2 times in handler the normal is one)
        }
    }
}
