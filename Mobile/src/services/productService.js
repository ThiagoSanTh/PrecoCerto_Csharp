import api from './api';

export async function listarProdutos() {
  const response = await api.get('/produtos');
  return response.data;
}

export async function buscarProdutosPorNome(nome) {
  const response = await api.post('/produtos/buscar', JSON.stringify(nome));
  return response.data;
}

export async function criarProduto(produto) {
  const response = await api.post('/produtos', produto);
  return response.data;
}

export async function atualizarProduto(id, produto) {
  await api.put(`/produtos/${id}`, produto);
}

export async function removerProduto(id) {
  await api.delete(`/produtos/${id}`);
}