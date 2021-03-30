using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.Pagamentos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    //http://localhost:5000/api/Pagamentos
    [Route("api/[controller]/")]
    [ApiController]
    public class PagamentosController : ControllerBase
    {
        public IPagamentoService _service { get; set; }
        public PagamentosController(IPagamentoService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("Compras")]
        public async Task<ActionResult> Post([FromBody] PagamentoDtoCreate Pagamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Pagamento.valor < 0)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed, "Os valores informados não são válidos");
            }
            try
            {
                var result = await _service.Post(Pagamento);
                if (result != null)
                {
                    if (Pagamento.valor > 100)
                    {
                        result.estado = "Aprovado";
                        return Ok(result);
                    }
                    else
                    {
                        result.estado = "Reprovado";
                        return Ok(result);
                    }
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
