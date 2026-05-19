import api from './api';

export async function listarLojas() {
  const { data } = await api.get('/Lojas');
  return data;
}

export async function obterLoja(id) {
  const { data } = await api.get(`/Lojas/${id}`);
  return data;
}

export async function criarLoja(loja) {
  const { data } = await api.post('/Lojas', loja);
  return data;
}

export async function atualizarLoja(id, loja) {
  await api.put(`/Lojas/${id}`, loja);
}

export async function buscarLojasPorNome(nome) {
  const { data } = await api.post('/Lojas/buscar', JSON.stringify(nome));
  return data;
}
