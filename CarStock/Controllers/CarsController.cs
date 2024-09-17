using Microsoft.AspNetCore.Mvc;

namespace CarStock.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly DealerRepository _dealerRepository;

        public CarsController(DealerRepository dealerRepository)
        {
            _dealerRepository = dealerRepository;
        }

        // List cars for a dealer
        [HttpGet("{dealerId}")]
        public ActionResult<List<Car>> GetCars(int dealerId)
        {
            var cars = _dealerRepository.GetCarsByDealer(dealerId);
            if (cars == null)
            {
                return NotFound("Dealer not found");
            }                
            return Ok(cars);
        }

        // Add a car
        [HttpPost("{dealerId}")]
        public IActionResult AddCar(int dealerId, Car car)
        {
            _dealerRepository.AddCar(dealerId, car);
            return Ok();
        }

        // Remove a car
        [HttpDelete("{dealerId}/{make}/{model}")]
        public IActionResult RemoveCar(int dealerId, string make, string model)
        {
            _dealerRepository.RemoveCar(dealerId, make, model);
            return Ok();
        }

        // Update car stock level
        [HttpPut("{dealerId}/{make}/{model}/{stockLevel}")]
        public IActionResult UpdateCarStock(int dealerId, string make, string model, int stockLevel)
        {
            _dealerRepository.UpdateCarStock(dealerId, make, model, stockLevel);
            return Ok();
        }

        // Search car by make and model
        [HttpGet("{dealerId}/search")]
        public ActionResult<Car> SearchCar(int dealerId, [FromQuery] string make, [FromQuery] string model)
        {
            var car = _dealerRepository.SearchCar(dealerId, make, model);
            if (car == null)
            {
                return NotFound("Car not found");
            }
            return Ok(car);
        }
    }
}
