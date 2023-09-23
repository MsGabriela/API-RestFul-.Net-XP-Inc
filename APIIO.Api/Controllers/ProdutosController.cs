using APIIO.Api.ViewModels;
using APIIO.Business.Interfaces.Repositories;
using APIIO.Business.Interfaces.Services;
using APIIO.Business.Models;
using APIIO.Business.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIIO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoViewModel>>> ObterTodos()
        {
            var produtos = await _produtoService.ObterTodos();
            return Ok(produtos);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> ObterPorId(Guid id)
        {
            var produto = await _produtoService.ObterPorId(id);
            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoViewModel>> Adicionar([FromBody]ProdutoViewModel produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(produto);
            }

            await _produtoService.Adicionar(produto);
            return Ok("Produto adicionado com sucesso!");
        }
      
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> Atualizar(Guid id, [FromBody] ProdutoViewModel produto)
        {
            if (id != produto.Id)
            {
                return NotFound("O id informado não é o mesmo que foi passado na query!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(produto);
            }


            await _produtoService.Atualizar(produto);
            return Ok(produto);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> Remover(Guid id)
        {
            var produto = await _produtoService.ObterPorId(id);

            if (produto == null)
            {
                return NotFound("O id informado não foi localizado!");
            }

            await _produtoService.Remover(id);

            return Ok("Produto removido com sucesso!");
        }
    }
}
