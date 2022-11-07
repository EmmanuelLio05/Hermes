using Microsoft.AspNetCore.Mvc;

namespace Hermes.Controllers {
    public class MomentoController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
