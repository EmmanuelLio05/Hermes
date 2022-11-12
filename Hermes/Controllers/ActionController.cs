using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hermes.Controllers {
    public class ActionController : Controller {
        public IActionResult Index() {
            return View();
        }

        [HttpPost("SetLight")]
        public async Task<IActionResult> SetLight([FromBody] bool bState) {
            return null;
        }

        [HttpPost("SetFan")]
        public async Task<IActionResult> SetFan([FromBody] bool bState) {
            return null;
        }

        [HttpPost("setWater")]
        public async Task<IActionResult> setWater([FromBody] bool bState) {
            return null;
        }
    }
}