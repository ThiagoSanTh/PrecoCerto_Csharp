const GOOGLE_MAPS_API_KEY = process.env.EXPO_PUBLIC_GOOGLE_MAPS_API_KEY;

/**
 * Consulta o ViaCEP para preencher endereço a partir do CEP informado.
 * Mantemos isso no mobile para reduzir digitação e evitar erro no cadastro da loja.
 */
export async function buscarEnderecoPorCep(cep) {
  const cepLimpo = cep.replace(/\D/g, '');

  if (cepLimpo.length !== 8) {
    throw new Error('CEP deve ter 8 dígitos.');
  }

  const response = await fetch(`https://viacep.com.br/ws/${cepLimpo}/json/`);
  const data = await response.json();

  if (data.erro) {
    throw new Error('CEP não encontrado.');
  }

  return {
    cep: cepLimpo,
    logradouro: data.logradouro || '',
    bairro: data.bairro || '',
    cidade: data.localidade || '',
    estado: data.uf || '',
  };
}

/**
 * Usa Google Geocoding API para converter endereço textual em latitude/longitude.
 * Configure EXPO_PUBLIC_GOOGLE_MAPS_API_KEY no ambiente antes de iniciar o Expo.
 */
export async function geocodificarEndereco(endereco) {
  if (!GOOGLE_MAPS_API_KEY) {
    throw new Error('Configure EXPO_PUBLIC_GOOGLE_MAPS_API_KEY para geocodificar endereço.');
  }

  const textoEndereco = [
    endereco.logradouro,
    endereco.numero,
    endereco.bairro,
    endereco.cidade,
    endereco.estado,
    endereco.cep,
  ]
    .filter(Boolean)
    .join(', ');

  const url = `https://maps.googleapis.com/maps/api/geocode/json?address=${encodeURIComponent(
    textoEndereco
  )}&key=${GOOGLE_MAPS_API_KEY}`;

  const response = await fetch(url);
  const data = await response.json();

  if (data.status !== 'OK' || !data.results?.length) {
    throw new Error('Google Maps não encontrou coordenadas para este endereço.');
  }

  const location = data.results[0].geometry.location;
  return {
    latitude: location.lat,
    longitude: location.lng,
  };
}
