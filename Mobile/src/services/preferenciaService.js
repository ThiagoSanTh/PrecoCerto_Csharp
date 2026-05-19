import api from './api';

export async function listarPreferenciasCliente(clienteId) {
  const { data } = await api.get(`/PreferenciasCliente/cliente/${clienteId}`);
  return data;
}

export async function criarPreferencia(preferencia) {
  const { data } = await api.post('/PreferenciasCliente', preferencia);
  return data;
}

export async function atualizarPreferencia(clienteId, chave, valor) {
  await api.put(`/PreferenciasCliente/cliente/${clienteId}?chave=${encodeURIComponent(chave)}`, { valor });
}
