using CarDealershipApi.Database;
using CarDealershipApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarDealershipApi.Controllers {
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase {

        private CarRepository _carRepository = new CarRepository();

        [HttpGet(Name = "GetCars")]
        public IEnumerable<CarPreview> Get() {
            return _carRepository.GetCarsPreviews();
        }

        [HttpGet("{id}")]
        public Car Get(string id) {
            return _carRepository.GetCars().Where(car => car.Id == id).FirstOrDefault();
        }
    }
}
