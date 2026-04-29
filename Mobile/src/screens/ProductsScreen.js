import { View, Text, Pressable, FlatList, Alert } from 'react-native';
import { useEffect, useState } from 'react';
import { listarProdutos } from '../services/productService';
import { styles } from '../style';

export default function ProductsScreen({ navigation }) {
  const [produtos, setProdutos] = useState([]);

  useEffect(() => {
    carregarProdutos();

    const unsubscribe = navigation.addListener('focus', () => {
      carregarProdutos();
    });

    return unsubscribe;
  }, [navigation]);

  async function carregarProdutos() {
    try {
      const dados = await listarProdutos();
      setProdutos(dados);
    } catch (error) {
      console.error(error?.response?.data || error.message);
      Alert.alert('Erro', 'Não foi possível carregar os produtos');
    }
  }

  function formatarPreco(valor) {
    return Number(valor).toLocaleString('pt-BR', {
      style: 'currency',
      currency: 'BRL'
    });
  }

  return (
    <View style={styles.container}>
      <Text style={styles.formTitle}>Produtos</Text>

      <Pressable
        style={styles.formButton}
        onPress={() => navigation.navigate('CreateProduct')}
      >
        <Text style={styles.textButton}>+ Novo Produto</Text>
      </Pressable>

      <FlatList
        data={produtos}
        keyExtractor={(item) => item.id}
        renderItem={({ item }) => (
          <View style={styles.card}>
            <Text>{item.nome || item.nomeProduto}</Text>
            <Text>{item.marca}</Text>
            <Text>{item.descricao}</Text>
            <Text>{formatarPreco(item.preco)}</Text>
          </View>
        )}
      />
    </View>
  );
}