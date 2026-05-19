import api from './api';

export async function registrarPesquisa(clienteId, termoPesquisa) {
  const { data } = await api.post('/HistoricoPesquisa', { clienteId, termoPesquisa });
  return data;
}

export async function listarHistoricoCliente(clienteId) {
  const { data } = await api.get(`/HistoricoPesquisa/cliente/${clienteId}`);
  return data;
}

export async function limparHistoricoCliente(clienteId) {
  await api.delete(`/HistoricoPesquisa/cliente/${clienteId}/limpar`);
}
