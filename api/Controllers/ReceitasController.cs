using System.Threading.Tasks;
using api.Data;
using api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers {
    
    [ApiController]
    [Route("[controller]")]
    public class ReceitasController : Controller {

        private readonly IReceitaRepository _receita;
        public ReceitasController(
            IReceitaRepository receita
        ){
            this._receita = receita;
        }

        [HttpGet]
        public async Task<IActionResult> get() {
            return Json(await _receita.findAll());
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> getByCodigo(string codigo) {
            return Json(await _receita.findByCodigo(codigo));
        }

        [HttpPost]
        public async Task<IActionResult> post(api.Model.Receita receita) {
            await _receita.add(receita);
            return Json(receita);
        }

        [HttpPut]
        public async Task<IActionResult> put(api.Model.Receita receita) {
            await _receita.update(receita);
            return Json(receita);
        }

        [HttpDelete]
        public async Task<IActionResult> delete(api.Model.Receita receita) {
            await _receita.delete(receita);
            return Ok();
        }
    }
}