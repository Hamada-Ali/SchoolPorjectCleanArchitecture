using FluentAssertions;
using Moq;
using SchoolProject.XUnit.Test.Models;
using SchoolProject.XUnit.Test.MoqTest;

namespace SchoolProject.XUnit.Test
{
    public class MoqCarTest
    {
        private readonly Mock<List<Car>> _mock = new Mock<List<Car>>();
        [Fact]
        public void Add_car()
        {
            // arrange
            var car = new Car() { Color = "red", Id = 1, Name = "BMW" };
            var carMoqService = new CarMoqService(_mock.Object);

            // act
            var addResult = carMoqService.AddCar(car);

            var carList = carMoqService.GetAll();
            // assert
            addResult.Should().BeTrue().And.NotBe(false);

            carList.Should().NotBeNull();
        }

        //[Fact]
        //public void Remove_car()
        //{
        //    // arrange
        //    var car = new Car() { Color = "white", Id = 5, Name = "BMW" };

        //    // act
        //    var addResult = _carMoqService.AddCar(car);

        //    var removeCar = _carMoqService.RemoveCar(9);

        //    removeCar.Should().BeTrue();
        //}

    }
}
