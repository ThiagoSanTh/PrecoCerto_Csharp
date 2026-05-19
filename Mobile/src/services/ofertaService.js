import api from './api';

export async function listarOfertas() {
  const { data } = await api.get('/Ofertas');
  return data;
}

export async function listarOfertasPorProduto(produtoId) {
  const { data } = await api.get(`/Ofertas/produto/${produtoId}`);
  return data;
}

export async function criarOferta(oferta) {
  const { data } = await api.post('/Ofertas', oferta);
  return data;
}

export async function atualizarOferta(id, oferta) {
  await api.put(`/Ofertas/${id}`, oferta);
}

export async function removerOferta(id) {
  await api.delete(`/Ofertas/${id}`);
}
