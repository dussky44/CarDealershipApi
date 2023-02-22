using CarDealershipApi.Models;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarDealershipApi.Database {
    public class CarRepository {

        private List<Car> _carList;
        public CarRepository() {
            LoadJson();
        }

        private void LoadJson() {
            var items = new List<Car>();
            using (StreamReader r = new StreamReader(@"Database/Data/Cars.json")) {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<Car>>(json);
            }
            _carList = items.ToList();
        }

        public List<Car> GetCars() { return _carList; }
        public List<CarPreview> GetCarsPreviews() {
            return _carList.Select(car => new CarPreview {
                Id = car.Id,
                Picture = car.Picture,
                Name = car.Name,
                Details = car.Details
            }).ToList();
        }

    }
}
