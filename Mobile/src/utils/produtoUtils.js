export function nomeProduto(produto) {
  return produto?.nome || produto?.nomeProduto || 'Produto';
}

export function filtrarProdutosPorTermo(produtos, termo) {
  const t = termo.trim().toLowerCase();
  if (!t) return produtos;

  return produtos.filter((p) => {
    const nome = nomeProduto(p).toLowerCase();
    const marca = (p.marca || '').toLowerCase();
    const descricao = (p.descricao || '').toLowerCase();
    const codigo = (p.codigoBarras || '').toLowerCase();
    return nome.includes(t) || marca.includes(t) || descricao.includes(t) || codigo.includes(t);
  });
}

/** Mescla produtos da loja (LojaId) com legado vinculado só por oferta. */
export function mesclarProdutosDaLoja(produtosPorLoja, todosProdutos, ofertas, lojaId) {
  const idsOferta = new Set(
    ofertas.filter((o) => o.lojaId === lojaId).map((o) => o.produtoId)
  );

  const map = new Map();
  produtosPorLoja.forEach((p) => map.set(p.id, p));
  todosProdutos
    .filter((p) => p.lojaId === lojaId || idsOferta.has(p.id))
    .forEach((p) => map.set(p.id, p));

  return [...map.values()];
}
