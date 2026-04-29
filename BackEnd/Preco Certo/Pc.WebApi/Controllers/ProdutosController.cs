using Microsoft.AspNetCore.Mvc;
using Pc.Dominio.Entities.Catalogo;
using Pc.Servico.Interfaces;
using Pc.WebApi.DTOs;

namespace Pc.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoServico _produtoServico;

        public ProdutosController(IProdutoServico produtoServico)
        {
            _produtoServico = produtoServico;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var produtos = await _produtoServico.ListarProdutosAsync();

            var resposta = produtos.Select(p => new ProdutoRespostaDto
            {
                Id = p.Id,
                Nome = p.NomeProduto,
                Descricao = p.Descricao,
                Marca = p.Marca ?? string.Empty,
                CodigoBarras = p.CodigoBarras ?? string.Empty,
                Preco = p.Preco
            });

            return Ok(resposta);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var produto = await _produtoServico.ObterPorIdAsync(id);

            if (produto is null)
                return NotFound("Produto não encontrado.");

            var resposta = new ProdutoRespostaDto
            {
                Id = produto.Id,
                Nome = produto.NomeProduto,
                Descricao = produto.Descricao,
                Marca = produto.Marca ?? string.Empty,
                CodigoBarras = produto.CodigoBarras ?? string.Empty,
                Preco = produto.Preco
            };

            return Ok(resposta);
        }

        [HttpPost("Buscar")]
        public async Task<IActionResult> BuscarPorNome([FromBody] string nome)
        {
            var produtos = await _produtoServico.BuscarPorNomeAsync(nome);

            var resposta = produtos.Select(p => new ProdutoRespostaDto
            {
                Id = p.Id,
                Nome = p.NomeProduto,
                Descricao = p.Descricao,
                Marca = p.Marca ?? string.Empty,
                CodigoBarras = p.CodigoBarras ?? string.Empty,
                Preco = p.Preco
            });

            return Ok(resposta);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] ProdutoCriarDto dto)
        {
            var produto = new Produto
            {
                NomeProduto = dto.NomeProduto,
                Descricao = dto.Descricao,
                Marca = dto.Marca,
                CodigoBarras = dto.CodigoBarras,
                Preco = dto.Preco
            };

            var novoProduto = await _produtoServico.AdicionarAsync(produto);

            var resposta = new ProdutoRespostaDto
            {
                Id = novoProduto.Id,
                Nome = novoProduto.NomeProduto,
                Descricao = novoProduto.Descricao,
                Marca = novoProduto.Marca ?? string.Empty,
                CodigoBarras = novoProduto.CodigoBarras ?? string.Empty,
                Preco = novoProduto.Preco
            };

            return CreatedAtAction(nameof(ObterPorId), new { id = resposta.Id }, resposta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] ProdutoCriarDto dto)
        {
            var produtoExistente = await _produtoServico.ObterPorIdAsync(id);

            if (produtoExistente is null)
                return NotFound("Produto não encontrado.");

            produtoExistente.NomeProduto = dto.NomeProduto;
            produtoExistente.Descricao = dto.Descricao;
            produtoExistente.Marca = dto.Marca;
            produtoExistente.CodigoBarras = dto.CodigoBarras;
            produtoExistente.Preco = dto.Preco;

            await _produtoServico.AtualizarAsync(produtoExistente);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            var produtoExistente = await _produtoServico.ObterPorIdAsync(id);

            if (produtoExistente is null)
                return NotFound("Produto não encontrado.");

            await _produtoServico.RemoverAsync(id);

            return NoContent();
        }
    }
}