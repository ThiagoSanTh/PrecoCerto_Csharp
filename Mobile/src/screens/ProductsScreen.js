import { View, Text, Pressable, FlatList, Dimensions } from 'react-native';
import { styles, colors } from '../style';
import { useEffect, useState } from 'react';
import AsyncStorage from '@react-native-async-storage/async-storage';

export default function ProductsScreen({ navigation }) {
  const [products, setProducts] = useState([]);

  const screenWidth = Dimensions.get('window').width;
  const numColumns = screenWidth > 600 ? 3 : 2;
  const itemWidth = screenWidth / numColumns - 20;

  useEffect(() => {
    loadProducts();

    const unsubscribe = navigation.addListener('focus', () => {
      loadProducts();
    });

    return unsubscribe;
  }, [navigation]);

  async function loadProducts() {
    const data = await AsyncStorage.getItem('@products');
    const lojaData = await AsyncStorage.getItem('@lojas');
    const loggedData = await AsyncStorage.getItem('@loggedUser');

    if (!data || !lojaData || !loggedData) return;

    const products = JSON.parse(data);
    const lojas = JSON.parse(lojaData);
    const user = JSON.parse(loggedData);

    const loja = lojas.find(l => l.userEmail === user.email);
    if (!loja) return;

    const myProducts = products.filter(p => p.lojaId === loja.id);

    setProducts(myProducts);
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
      </View>
    );
  }

  return (
    <View style={styles.container}>
      <Text style={styles.formTitle}>Meus Produtos 📦</Text>

      <Pressable
        style={styles.formButton}
        onPress={() => navigation.navigate('CreateProduct')}
      >
        <Text style={styles.textButton}>+ Novo Produto</Text>
      </Pressable>

      <FlatList
        data={products}
        keyExtractor={(item) => item.id}
        renderItem={renderItem}
        numColumns={numColumns}
        columnWrapperStyle={{ justifyContent: 'space-between' }}
        style={{ marginTop: 20 }}
      />
    </View>
  );
}