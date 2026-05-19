import { FlatList, Alert, ActivityIndicator } from 'react-native';
import { useCallback, useState, useMemo } from 'react';
import { useFocusEffect } from '@react-navigation/native';
import { listarProdutosParaFeed, buscarProdutosPorNome } from '../services/productService';
import { registrarPesquisa } from '../services/historicoService';
import { useAuth } from '../context/AuthContext';
import {
  FormScreen,
  FormField,
  PrimaryButton,
  ListCard,
  ListCardText,
  formStyles,
} from '../components/form';
import { colors } from '../style';
import { filtrarProdutosPorTermo, nomeProduto } from '../utils/produtoUtils';

export default function SearchScreen() {
  const [termoBusca, setTermoBusca] = useState('');
  const [produtosBase, setProdutosBase] = useState([]);
  const [resultadosBusca, setResultadosBusca] = useState(null);
  const [loading, setLoading] = useState(true);
  const { session, isCliente, sincronizarGpsCliente } = useAuth();

  const clienteId = session?.perfil?.id;

  useFocusEffect(
    useCallback(() => {
      carregar();
      if (isCliente) sincronizarGpsCliente();
    }, [clienteId, isCliente])
  );

  async function carregar() {
    setLoading(true);
    setResultadosBusca(null);
    try {
      const lista = await listarProdutosParaFeed(null);
      setProdutosBase(Array.isArray(lista) ? lista : []);
    } catch (error) {
      const detalhe =
        error.response?.data?.title ||
        error.response?.data ||
        error.message ||
        'Erro desconhecido';
      console.error('carregar produtos:', detalhe);
      Alert.alert(
        'Erro',
        'Não foi possível carregar os produtos. Verifique se a API está rodando e se a migration AddLojaIdToProduto foi aplicada no banco.'
      );
    } finally {
      setLoading(false);
    }
  }

  async function handleSearch() {
    const termo = termoBusca.trim();

    if (!termo) {
      setResultadosBusca(null);
      return;
    }

    setLoading(true);
    try {
      let filtrados = filtrarProdutosPorTermo(produtosBase, termo);

      if (filtrados.length === 0) {
        filtrados = await buscarProdutosPorNome(termo);
      }

      setResultadosBusca(filtrados);

      if (clienteId) {
        await registrarPesquisa(clienteId, termo);
      }
    } catch {
      Alert.alert('Erro', 'Falha na busca');
    } finally {
      setLoading(false);
    }
  }

  const produtosExibidos = useMemo(() => {
    const base = resultadosBusca ?? produtosBase;
    if (resultadosBusca) return resultadosBusca;
    return filtrarProdutosPorTermo(base, termoBusca);
  }, [produtosBase, resultadosBusca, termoBusca]);

  function formatarPreco(valor) {
    return Number(valor).toLocaleString('pt-BR', {
      style: 'currency',
      currency: 'BRL',
    });
  }

  function renderItem({ item }) {
    return (
      <ListCard title={nomeProduto(item)}>
        <ListCardText>{item.marca}</ListCardText>
        {item.descricao ? <ListCardText>{item.descricao}</ListCardText> : null}
        <ListCardText>{formatarPreco(item.preco)}</ListCardText>
      </ListCard>
    );
  }

  return (
    <FormScreen
      title="Buscar produtos"
      subtitle="Todos os produtos do catálogo"
      scrollable={false}
    >
      <FormField
        label="Buscar"
        value={termoBusca}
        onChangeText={(texto) => {
          setTermoBusca(texto);
          if (!texto.trim()) setResultadosBusca(null);
        }}
        placeholder="Nome, marca ou descrição..."
        onSubmitEditing={handleSearch}
        returnKeyType="search"
      />
      <PrimaryButton label="Buscar" onPress={handleSearch} style={{ marginBottom: 12 }} />

      {loading ? (
        <ActivityIndicator size="large" color={colors.primary} style={{ marginTop: 24 }} />
      ) : (
        <FlatList
          style={formStyles.listFlex}
          data={produtosExibidos}
          keyExtractor={(item) => item.id}
          renderItem={renderItem}
          showsVerticalScrollIndicator={false}
          keyboardShouldPersistTaps="handled"
          ListEmptyComponent={
            <ListCardText>
              {termoBusca.trim()
                ? 'Nenhum produto encontrado para essa busca.'
                : 'Nenhum produto cadastrado ainda.'}
            </ListCardText>
          }
        />
      )}
    </FormScreen>
  );
}
