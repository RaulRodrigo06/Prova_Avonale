using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Api.Domain.Dtos.Products;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/compras")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private IProductService _service;
        private IError _error;
        public ComprasController(IProductService service, IError error)
        {
            _service = service;
            _error = error;
        }

        ///

        ///
        [HttpPost]
        public async Task<ActionResult> Compras([FromBody] PagamentoDto pagamento)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Ocorreu um Erro Desconhecido");
            }
            var retorno = await _service.RequestExterno(pagamento);
            if (_error.ErrorMessages.Any())
            {
                return BadRequest(_error.ErrorMessages);
            }
            if (retorno == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Ocorreu um Erro Desconhecido");
            }
            return Ok(retorno);
        }
    }
}
