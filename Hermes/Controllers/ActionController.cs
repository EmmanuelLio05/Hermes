using Microsoft.AspNetCore.Mvc;

namespace Hermes.Controllers {
    public class ActionController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}