namespace Lection1.Models
{
    public interface ICar
    {
        public List<Car> GetCars();
        public void AddCar(Car car);

        public void RemoveCar(Car car);
        public void EditCar(int carID, Car car);
        public Car GetCar(int carID);


    }
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CarService : ICar
    {

        private List<Car> _cars = new List<Car>();

        public List<Car> GetCars()
        {
            return _cars;
        }
        public void AddCar(Car car)
        {
            _cars.Add(car);
        }

        public void RemoveCar(Car car)
        {
            _cars.Remove(car);
        }
        public void EditCar(int carID, Car car)
        {
            var existingCar = _cars.FirstOrDefault(c => c.Id == carID);
            if (existingCar != null)
            {
                existingCar.Name = car.Name;
                existingCar.Description = car.Description;
            }
        }

        public Car GetCar(int carID)
        {
            return _cars.FirstOrDefault(c => c.Id == carID);
        }
    }
    /*
     Разработайте веб-страницу с использованием ASP.NET Core Razor Pages, которая принимает массив объектов класса Car и отображает их на страницу. Для хранения автомобилей использовать сервис с жизненным циклом – Singleton.
    Принимать массив объектов она может 2-мя способами:
    1) Get запросом, через строку запроса.
    2) Post запросом, например через форму.
     */
}