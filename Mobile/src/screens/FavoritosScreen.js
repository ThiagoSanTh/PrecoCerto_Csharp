import { Pressable, FlatList, Alert, ActivityIndicator } from 'react-native';
import { useCallback, useState } from 'react';
import { useFocusEffect } from '@react-navigation/native';
import { listarFavoritosCliente, removerFavorito } from '../services/favoritoService';
import { useAuth } from '../context/AuthContext';
import {
  FormScreen,
  ListCard,
  ListCardText,
  formStyles,
} from '../components/form';
import { colors } from '../style';

export default function FavoritosScreen() {
  const [favoritos, setFavoritos] = useState([]);
  const [loading, setLoading] = useState(true);
  const { session } = useAuth();
  const clienteId = session?.perfil?.id;

  useFocusEffect(
    useCallback(() => {
      carregar();
    }, [clienteId])
  );

  async function carregar() {
    if (!clienteId) return;
    setLoading(true);
    try {
      const data = await listarFavoritosCliente(clienteId);
      setFavoritos(data);
    } catch {
      Alert.alert('Erro', 'Não foi possível carregar favoritos');
    } finally {
      setLoading(false);
    }
  }

  async function handleRemover(id) {
    try {
      await removerFavorito(id);
      setFavoritos((prev) => prev.filter((f) => f.id !== id));
    } catch {
      Alert.alert('Erro', 'Não foi possível remover');
    }
  }

  if (!clienteId) {
    return (
      <FormScreen title="Favoritos" subtitle="Faça login como cliente">
        <ListCardText>Nenhuma sessão de cliente ativa.</ListCardText>
      </FormScreen>
    );
  }

  return (
    <FormScreen title="Favoritos" subtitle="Produtos e lojas salvos" scrollable={false}>
      {loading ? (
        <ActivityIndicator color={colors.primary} style={{ marginTop: 24 }} />
      ) : (
        <FlatList
          style={formStyles.listFlex}
          data={favoritos}
          keyExtractor={(item) => item.id}
          showsVerticalScrollIndicator={false}
          renderItem={({ item }) => (
            <ListCard title={item.nomeProduto || item.nomeLoja || 'Favorito'}>
              {item.nomeLoja ? <ListCardText>{item.nomeLoja}</ListCardText> : null}
              <Pressable onPress={() => handleRemover(item.id)} style={{ marginTop: 8 }}>
                <ListCardText style={formStyles.dangerText}>Remover</ListCardText>
              </Pressable>
            </ListCard>
          )}
          ListEmptyComponent={<ListCardText>Nenhum favorito ainda.</ListCardText>}
        />
      )}
    </FormScreen>
  );
}
