using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.Pagamentos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    //http://localhost:5000/api/Pagamentos
    [Route("api/pagamento")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        public IPagamentoService _service { get; set; }
        public PagamentoController(IPagamentoService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("compras")]
        public async Task<ActionResult> Post([FromBody] PagamentoDtoCreate pagamento)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Ocorreu um Erro Desconhecido");
            }
            if (pagamento.Valor < 0)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed, "Os valores informados não são válidos");
            }
            try
            {
                var result = _service.ProcessarPagamento(pagamento);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
