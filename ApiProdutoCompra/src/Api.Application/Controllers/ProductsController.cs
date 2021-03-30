using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Domain.Dtos.Products;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    //http://localhost:8080/api/Products
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public IProductService _service { get; set; }
        public ProductsController(IProductService service)
        {
            _service = service;
        }

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

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDtoCreate product)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Ocorreu um erro Desconhecido");
            }

            if (product.qntd_estoque < 0 || product.valor_unitario < 0)
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

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ProductDtoUpdate product)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Ocorreu um erro Desconhecido");
            }
            if (product.qntd_estoque < 0 || product.valor_unitario < 0)
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
