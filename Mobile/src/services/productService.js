import api from './api';

export async function listarProdutos() {
  const response = await api.get('/produtos');
  return response.data;
}

export async function buscarProdutosPorNome(nome) {
  const response = await api.get(`/produtos/buscar?nome=${encodeURIComponent(nome)}`);
  return response.data;
}

export async function criarProduto(produto) {
  const response = await api.post('/produtos', produto);
  return response.data;
}

export async function atualizarProduto(id, produto) {
  const response = await api.put(`/produtos/${id}`, produto);
  return response.data;
}

export async function removerProduto(id) {
  const response = await api.delete(`/produtos/${id}`);
  return response.data;
}