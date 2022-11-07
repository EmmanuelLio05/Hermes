using Microsoft.AspNetCore.Mvc;

namespace Hermes.Controllers {
    public class PlantaController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
