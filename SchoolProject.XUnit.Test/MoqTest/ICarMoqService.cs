using SchoolProject.XUnit.Test.TestModels;

namespace SchoolProject.XUnit.Test.MoqTest
{
    public interface ICarMoqService
    {
        public bool AddCar(Car car);
        public bool RemoveCar(int id);
        public List<Car> GetAll();
    }
}
