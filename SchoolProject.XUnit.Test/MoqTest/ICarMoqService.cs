using SchoolProject.XUnit.Test.Models;

namespace SchoolProject.XUnit.Test.MoqTest
{
    public interface ICarMoqService
    {
        public bool AddCar(Car car);
        public bool RemoveCar(int id);
        public List<Car> GetAll();
    }
}
