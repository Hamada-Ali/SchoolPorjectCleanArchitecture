using AutoMapper;
using EntityFrameworkCore.Testing.Common;
using FluentAssertions;
using Microsoft.Extensions.Localization;
using Moq;
using SchoolProject.Core.Features.Students.Queries.Dto;
using SchoolProject.Core.Features.Students.Queries.Handlers;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Mapping.Students;
using SchoolProject.Core.Resources;
using SchoolProject.Domain.Entities;
using SchoolProject.Domain.Helpers;
using SchoolProject.Services.Interface;
using System.Net;

namespace SchoolProject.XUnit.Test.CoreTest.Students.Queries
{
    public class StudentQueryHandlerTest
    {

        private readonly Mock<IStudentService> _studentServiceMock;
        private readonly IMapper _imapperMock;
        private readonly Mock<IStringLocalizer<SharedResources>> _stringLocalizerMock;
        private readonly StudentProfile _studentProfile;
        public StudentQueryHandlerTest()
        {
            _studentProfile = new StudentProfile();
            _studentServiceMock = new Mock<IStudentService>();
            //_imapperMock = new();
            _stringLocalizerMock = new();
            var configration = new MapperConfiguration(c => c.AddProfile(_studentProfile));
            _imapperMock = new Mapper(configration);
        }

        [Fact]
        public async Task StudentList_Should_not_null_and_Not_Empty()
        {
            #region Arrage
            var studentList = new List<Student>() // pass fake object
            {
                new Student() {StudId = 1, Address = "Alex", DID = 1, NameAr = "محمد", NameEn = "Mohamed"}
            };
            var query = new GetStudentListQuery();
            _studentServiceMock.Setup(x => x.GetStudentsListAsync()).Returns(Task.FromResult(studentList)); // handle mapping problem
            var handler = new StudentQueryHandler(_studentServiceMock.Object, _imapperMock, _stringLocalizerMock.Object);
            #endregion

            #region act
            var result = await handler.Handle(query, default);
            #endregion

            #region assert
            result.Data.Should().NotBeNullOrEmpty();
            result.Succeeded.Should().BeTrue();
            result.Data.Should().BeOfType<List<StudentDto>>();
            #endregion
        }

        [Theory]
        [InlineData(66)]
        //[InlineData(2)]
        public async Task Handle_StudentById_when_student_Notfound_return_404(int id)
        {
            #region Arrage
            var department = new Department() { DID = 1, DNameAr = "هندسة البرمجيات", DNameEn = "SE" };
            var studentList = new List<Student>() // pass fake object
            {
                new Student() {StudId = 1, Address = "Alex", DID = 1, NameAr = "محمد", NameEn = "Mohamed", Department = department},
                new Student() {StudId = 2, Address = "Cairo", DID = 1, NameAr = "على", NameEn = "Ali", Department = department},
            };
            var query = new GetStudentByIdQuery(id);
            _studentServiceMock.Setup(x => x.GetStudentByIdAsync(id)).Returns(Task.FromResult(studentList.FirstOrDefault(x => x.StudId == id))); // handle mapping problem
            var handler = new StudentQueryHandler(_studentServiceMock.Object, _imapperMock, _stringLocalizerMock.Object);
            #endregion

            #region act
            var result = await handler.Handle(query, default);
            #endregion

            #region assert
            result.StatusCode.Should().Be(HttpStatusCode.NotFound);

            #endregion
        }

        [Theory]
        [InlineData(1)]
        //[InlineData(2)]
        public async Task Handle_StudentById_when_student_Notfound_return_200(int id)
        {
            #region Arrage
            var department = new Department() { DID = 1, DNameAr = "هندسة البرمجيات", DNameEn = "SE" };
            var studentList = new List<Student>() // pass fake object
            {
                new Student() {StudId = 1, Address = "Alex", DID = 1, NameAr = "محمد", NameEn = "Mohamed", Department = department},
                new Student() {StudId = 2, Address = "Cairo", DID = 1, NameAr = "على", NameEn = "Ali", Department = department},
            };
            var query = new GetStudentByIdQuery(id);
            _studentServiceMock.Setup(x => x.GetStudentByIdAsync(id)).Returns(Task.FromResult(studentList.FirstOrDefault(x => x.StudId == id))); // handle mapping problem
            var handler = new StudentQueryHandler(_studentServiceMock.Object, _imapperMock, _stringLocalizerMock.Object);
            #endregion

            #region act
            var result = await handler.Handle(query, default);
            #endregion

            #region assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.StudId.Should().Be(id);
            result.Data.Name.Should().Be("Mohamed");
            #endregion
        }

        [Fact]
        public async Task StudentList_Paginated_Should_not_null_and_Not_Empty()
        {
            #region Arrage
            var department = new Department() { DID = 1, DNameAr = "هندسة البرمجيات", DNameEn = "SE" };

            var studentList = new AsyncEnumerable<Student>(new List<Student> {

                new Student() {StudId = 1, Address = "Alex", DID = 1, NameAr = "محمد", NameEn = "Mohamed", Department = department}

            }); // pass fake object
            var query = new GetStudentPaginatedListQuery() { PageNumber = 1, PageSize = 10, OrderBy = StudentOrderyingEnum.StudId, Search = "Mohamed" };
            _studentServiceMock.Setup(x => x.FilterStudentPaginatedQueryable(query.OrderBy, query.Search)).Returns(studentList.AsQueryable()); // handle mapping problem
            var handler = new StudentQueryHandler(_studentServiceMock.Object, _imapperMock, _stringLocalizerMock.Object);
            #endregion

            #region act
            var result = await handler.Handle(query, default);
            #endregion

            #region assert
            result.Data.Should().NotBeNullOrEmpty();
            result.Succeeded.Should().BeTrue();
            result.Data.Should().BeOfType<List<StudentPaginatedList>>();
            #endregion
        }
    }
}
