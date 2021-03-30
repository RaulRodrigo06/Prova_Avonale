using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
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
            if (pagamento.Cartao.cvv.Length != 3 || pagamento.Cartao.numero.Length != 16)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed, "Os valores informados não são válidos");
            }
            var bandeiracartao = new List<string> { "VISA", "Mastercard", "AMEX", "Diners Club", "Discover", "Hipercard", "Inter" };
            if (!bandeiracartao.Contains(pagamento.Cartao.bandeira))
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed, "Não aceitamos essa bandeira");
            }
            string[] date = pagamento.Cartao.data_expiracao.Split('/');
            if (int.Parse(date[1]) < DateTime.Now.Year)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed, "Data do Cartão Expirada");
            }
            if (int.Parse(date[0]) < DateTime.Now.Month && int.Parse(date[1]) == DateTime.Now.Month)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed, "Data do Cartão Expirada");
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
