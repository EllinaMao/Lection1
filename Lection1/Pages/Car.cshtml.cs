using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lection1.Models;
using System.Text.Json;

namespace Lection1.Pages
{
    public class CarModel : PageModel
    {
        private readonly ICar _carService;
        public List<Car> Cars { get; set; } = new List<Car>();
        public CarModel(ICar carService)
        {
            _carService = carService;
        }

        public void OnGet()
        {
            Cars=_carService.GetCars();
        }

    }
}
