namespace CarStock
{
    public class DealerRepository
    {
        private readonly Dictionary<int, Dealer> _dealers = new();

        public DealerRepository()
        {
            // Simulate a few dealers and car stocks
            _dealers.Add(1, new Dealer
            {
                Id = 1,
                Name = "Dealer1",
                Cars = new List<Car>
            {
                new Car { Make = "Audi", Model = "A4", Year = 2018, StockLevel = 5 }
            }
            });

            _dealers.Add(2, new Dealer
            {
                Id = 2,
                Name = "Dealer2",
                Cars = new List<Car>
            {
                new Car { Make = "BMW", Model = "X5", Year = 2019, StockLevel = 3 }
            }
            });
        }

        public List<Car> GetCarsByDealer(int dealerId) => _dealers.ContainsKey(dealerId) ? _dealers[dealerId].Cars : null;
        public void AddCar(int dealerId, Car car) => _dealers[dealerId]?.Cars.Add(car);
        public void RemoveCar(int dealerId, string make, string model)
        {
            var dealer = _dealers[dealerId];
            dealer?.Cars.RemoveAll(c => c.Make == make && c.Model == model);
        }
        public void UpdateCarStock(int dealerId, string make, string model, int stockLevel)
        {
            var dealer = _dealers[dealerId];
            var car = dealer?.Cars.FirstOrDefault(c => c.Make == make && c.Model == model);
            if (car != null) car.StockLevel = stockLevel;
        }
        public Car SearchCar(int dealerId, string make, string model) =>
            _dealers[dealerId]?.Cars.FirstOrDefault(c => c.Make == make && c.Model == model);
    }
}
