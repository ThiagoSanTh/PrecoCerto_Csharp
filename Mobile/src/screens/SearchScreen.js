import { View, Text, TextInput, FlatList, Dimensions } from 'react-native';
import { styles, colors } from '../style';
import { useEffect, useState } from 'react';
import AsyncStorage from '@react-native-async-storage/async-storage';

export default function SearchScreen() {
  const [search, setSearch] = useState('');
  const [products, setProducts] = useState([]);
  const [lojas, setLojas] = useState([]);

  const screenWidth = Dimensions.get('window').width;
  const numColumns = screenWidth > 600 ? 3 : 2;
  const itemWidth = screenWidth / numColumns - 20;

  useEffect(() => {
    loadData();
  }, []);

  async function loadData() {
    const productData = await AsyncStorage.getItem('@products');
    const lojaData = await AsyncStorage.getItem('@lojas');

    if (productData) setProducts(JSON.parse(productData));
    if (lojaData) setLojas(JSON.parse(lojaData));
  }

  const filteredProducts = products.filter(p =>
    p.nome.toLowerCase().includes(search.toLowerCase())
  );

  function getLojaNome(lojaId) {
    const loja = lojas.find(l => l.id === lojaId);
    return loja ? loja.nomeFantasia : 'Loja não encontrada';
  }

  function renderItem({ item }) {
    return (
      <View
        style={styles.card}
      >
        <Text style={{ color: colors.text, fontWeight: 'bold' }}>
          {item.nome}
        </Text>

        <Text style={{ color: colors.text, marginTop: 5 }}>
          R$ {item.preco}
        </Text>

        <Text style={{ color: colors.text, marginTop: 5 }}>
          🏪 {getLojaNome(item.lojaId)}
        </Text>
      </View>
    );
  }

  return (
    <View style={styles.container}>
      <Text style={styles.formTitle}>Buscar Produtos 🔍</Text>

      <TextInput
        style={styles.formInput}
        placeholder="Digite o produto..."
        value={search}
        onChangeText={setSearch}
      />

      <FlatList
        data={filteredProducts}
        keyExtractor={(item) => item.id}
        renderItem={renderItem}
        numColumns={numColumns}
        columnWrapperStyle={{ justifyContent: 'space-between' }}
        style={{ marginTop: 20 }}
      />
    </View>
  );
}