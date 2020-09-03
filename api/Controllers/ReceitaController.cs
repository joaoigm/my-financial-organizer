using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers {
    
    [ApiController]
    [Route("[controller]")]
    public class ReceitaController : Controller {

        private DefaultContext _context;
        public ReceitaController(
            DefaultContext context
        ){
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> get() {
            return Json(await this._context.getConnection());
        }
    }
}