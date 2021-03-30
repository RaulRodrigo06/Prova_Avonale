using System.Threading.Tasks;
using Api.Domain.Dtos.Products;
using Api.Domain.Interfaces.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/compras")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        public IProductService _service { get; set; }
        public ComprasController(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> Compras([FromBody] PagamentoDto pagamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Ocorreu um erro desconhecido");
            }
            var retorno = await _service.RequestExterno(pagamento);
            if (retorno == null)
            {
                return BadRequest("Ocorreu um erro desconhecido");
            }
            return Ok(retorno);
        }
    }
}
