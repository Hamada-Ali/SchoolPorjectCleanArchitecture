using EntityFrameworkCore.Testing.Common;
using FluentAssertions;
using Moq;
using SchoolProject.Core.Wrappers;
using SchoolProject.Domain.Entities;
using SchoolProject.XUnit.Test.Wrappers.Interfaces;

namespace SchoolProject.XUnit.Test.ServiceTest.ExtentionMethod
{
    public class ExtensionMethodTest
    {
        private readonly Mock<IPaginatedService<Student>> _paginatedServiceMock;
        public ExtensionMethodTest()
        {
            _paginatedServiceMock = new();
        }
        [Theory]
        [InlineData(1, 10)]
        public async Task ToPainatedListAsync_should_return_list(int pageSize, int PageNumber)
        {

            // arrage
            var department = new Department() { DID = 1, DNameAr = "هندسة البرمجيات", DNameEn = "SE" };
            var studentList = new AsyncEnumerable<Student>(new List<Student> {

                new Student() {StudId = 1, Address = "Alex", DID = 1, NameAr = "محمد", NameEn = "Mohamed", Department = department}

            });
            var PaginatedResult = new PaginatedResult<Student>(studentList.ToList());

            _paginatedServiceMock.Setup(x => x.ReturnPaginatedResult(studentList, pageSize, PageNumber)).Returns(Task.FromResult(PaginatedResult));
            // act

            var result = await _paginatedServiceMock.Object.ReturnPaginatedResult(studentList, pageSize, PageNumber);
            // assert

            result.Data.Should().NotBeNullOrEmpty();
        }

    }
}
