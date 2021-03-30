using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.Products;
using Api.Domain.Interfaces.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    //http://localhost:8080/api/Products
    [Route("api/produtos")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public IProductService _service { get; set; }
        public ProductsController(IProductService service)
        {
            _service = service;
        }

        // GETAll api/produtos
        /// <summary>
        /// Lista todos os produtos.
        /// </summary>
        /// <returns>Os produtos que estão no Banco de Dados</returns>
        /// <response code="200">Retorna os produtos cadastrados</response>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Ocorreu um erro Desconhecido"); // 400 Bad Request - Solicitação Inválida
            }
            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Ocorreu um erro Desconhecido");
            }
        }

        // GET api/produtos/{id}
        /// <summary>
        /// Lista um produto pelo Id.
        /// </summary>
        /// <returns>O produto específico</returns>
        /// <response code="200">Retorna o produto do ID</response>
        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Ocorreu um erro Desconhecido");
            }
            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Ocorreu um erro Desconhecido");
            }
        }

        // POST api/produtos
        /// <summary>
        /// Cria um produto no banco de dados.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /produtos
        ///     {
        ///        "nome": "Macbook13\" 8GB|256SSD|2.7Ghz",
        ///        "valor_unitario": 8450.0,
        ///        "qtde_estoque": 5
        ///     }
        ///
        /// </remarks>
        /// <returns>Mensagem Produto Cadastrado</returns>
        /// <response code="200">Produto Cadastrado</response>
        /// <response code="400">Ocorreu Um erro Desconhecido</response> 
        /// <response code="412">Os valores informados não são válidos</response> 
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDtoCreate product)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Ocorreu um erro Desconhecido");
            }

            if (product.qtde_estoque < 0 || product.valor_unitario < 0)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed, "Os valores informados não são válidos");
            }
            try
            {
                var result = await _service.Post(product);
                if (result != null)
                {
                    return StatusCode((int)HttpStatusCode.OK, "Produto Cadastrado");
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, "Ocorreu um erro Desconhecido");
                }
            }
            catch (ArgumentException)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Ocorreu um erro Desconhecido");
            }
        }


        // Delete api/produtos/{id}
        /// <summary>
        /// Deleta um produto pelo Id.
        /// </summary>
        /// <returns>Mensagem de produto deletado</returns>
        /// <response code="200">Retorna Produto excluído com sucesso</response>
        /// <response code="400">Ocorreu um erro Desconhecido</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Ocorreu um erro Desconhecido");
            }
            try
            {
                var result = await _service.Delete(id);
                if (result == true)
                {
                    return StatusCode((int)HttpStatusCode.OK, "Produto Excluído com sucesso");
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, "Ocorreu um erro Desconhecido");
                }

            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // PUT api/produtos
        /// <summary>
        /// Atualiza um produto no banco de dados.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     PUT /produtos
        ///     {
        ///        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///        "nome": "string",
        ///        "valor_unitario": 0,
        ///        "qtde_estoque": 0
        ///     }
        ///
        /// </remarks>
        /// <returns>Retorna o produto</returns>
        /// <response code="200">Retorna o produto</response>
        /// <response code="400">Ocorreu Um erro Desconhecido</response> 
        /// <response code="412">Os valores informados não são válidos</response> 
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ProductDtoUpdate product)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Ocorreu um erro Desconhecido");
            }
            if (product.qtde_estoque < 0 || product.valor_unitario < 0)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed, "Os valores informados não são válidos");
            }
            try
            {
                var result = await _service.Put(product);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, "Ocorreu um erro Desconhecido");
                }
            }
            catch (ArgumentException)
            {

                return StatusCode((int)HttpStatusCode.BadRequest, "Ocorreu um erro Desconhecido");
            }
        }
    }
}
