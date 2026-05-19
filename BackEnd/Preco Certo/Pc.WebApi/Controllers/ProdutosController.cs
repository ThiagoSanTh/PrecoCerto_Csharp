using Microsoft.AspNetCore.Mvc;
using Pc.Dominio.Entities.Catalogo;
using Pc.Servico.Interfaces;
using Pc.WebApi.DTOs.Catalogo;

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
        public async Task<IActionResult> Listar([FromQuery] Guid? lojaId)
        {
            var produtos = await _produtoServico.ListarProdutosAsync(lojaId);
            return Ok(produtos.Select(MapearResposta));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var produto = await _produtoServico.ObterPorIdAsync(id);

            if (produto is null)
                return NotFound("Produto não encontrado.");

            return Ok(MapearResposta(produto));
        }

        [HttpPost("Buscar")]
        public async Task<IActionResult> BuscarPorNome([FromBody] ProdutoBuscarDto dto)
        {
            var produtos = await _produtoServico.BuscarPorNomeAsync(dto.Nome, dto.LojaId);
            return Ok(produtos.Select(MapearResposta));
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
                Preco = dto.Preco,
                LojaId = dto.LojaId
            };

            var novoProduto = await _produtoServico.AdicionarAsync(produto);
            return CreatedAtAction(nameof(ObterPorId), new { id = novoProduto.Id }, MapearResposta(novoProduto));
        }

        [HttpPut("{id:guid}")]
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
            if (dto.LojaId.HasValue)
                produtoExistente.LojaId = dto.LojaId;

            await _produtoServico.AtualizarAsync(produtoExistente);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            var produtoExistente = await _produtoServico.ObterPorIdAsync(id);

            if (produtoExistente is null)
                return NotFound("Produto não encontrado.");

            await _produtoServico.RemoverAsync(id);

            return NoContent();
        }

        private static ProdutoRespostaDto MapearResposta(Produto p) => new()
        {
            Id = p.Id,
            Nome = p.NomeProduto,
            Descricao = p.Descricao,
            Marca = p.Marca ?? string.Empty,
            CodigoBarras = p.CodigoBarras ?? string.Empty,
            Preco = p.Preco,
            LojaId = p.LojaId
        };
    }
}
