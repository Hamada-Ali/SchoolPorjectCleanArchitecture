using SchoolProject.XUnit.Test.Models;

namespace SchoolProject.XUnit.Test.MoqTest
{
    public class CarMoqService : ICarMoqService
    {

        public List<Car> cars = new List<Car>()
        {
            new Car { Id = 2, Color = "red", Name = "mercedes"},
            new Car { Id = 4, Color = "black", Name = "mercedes"},
            new Car { Id = 6, Color = "oragne", Name = "mercedes"},
            new Car { Id = 9, Color = "blue", Name = "mercedes"},
        };

        public CarMoqService(List<Car> cars)
        {

            this.cars = cars;
        }

        public bool AddCar(Car car)
        {
            cars.Add(car);
            return true;
        }

        public List<Car> GetAll()
        {
            return cars;
        }

        public bool RemoveCar(int id)
        {
            var removeCar = cars.ToList().FirstOrDefault(x => x.Id == id);

            if (removeCar == null) { return false; }
            cars.Remove(removeCar);
            return true;

        }
    }
}
