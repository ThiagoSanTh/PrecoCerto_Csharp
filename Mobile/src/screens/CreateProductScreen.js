import { View, Text, TextInput, Pressable, Alert } from 'react-native';
import { styles } from '../style';
import { useState } from 'react';
import AsyncStorage from '@react-native-async-storage/async-storage';

export default function CreateProductScreen({ navigation }) {
  const [nome, setNome] = useState('');
  const [preco, setPreco] = useState('');

  async function handleCreateProduct() {
    if (!nome || !preco) {
      Alert.alert('Erro', 'Preencha todos os campos');
      return;
    }
  
    const lojaData = await AsyncStorage.getItem('@lojas');
    const loggedData = await AsyncStorage.getItem('@loggedUser');
  
    if (!lojaData || !loggedData) {
      Alert.alert('Erro', 'Loja não encontrada');
      return;
    }
  
    const lojas = JSON.parse(lojaData);
    const user = JSON.parse(loggedData);
  
    // 🔍 acha a loja do usuário
    const loja = lojas.find(l => l.userEmail === user.email);
  
    if (!loja) {
      Alert.alert('Erro', 'Você não possui uma loja');
      return;
    }
  
    const newProduct = {
      id: Date.now().toString(),
      nome,
      preco,
      lojaId: loja.id // 🔥 vínculo aqui
    };
  
    const data = await AsyncStorage.getItem('@products');
    let products = data ? JSON.parse(data) : [];
  
    products.push(newProduct);
  
    await AsyncStorage.setItem('@products', JSON.stringify(products));
  
    Alert.alert('Sucesso', 'Produto criado!');
  
    navigation.goBack();
  }

  return (
    <View style={styles.container}>
      <Text style={styles.formTitle}>Novo Produto 📦</Text>

      <TextInput
        style={styles.formInput}
        placeholder="Nome do produto"
        value={nome}
        onChangeText={setNome}
      />

      <TextInput
        style={styles.formInput}
        placeholder="Preço"
        keyboardType="numeric"
        value={preco}
        onChangeText={setPreco}
      />

      <Pressable style={styles.formButton} onPress={handleCreateProduct}>
        <Text style={styles.textButton}>Salvar Produto</Text>
      </Pressable>

      <Pressable
        style={styles.formButton}
        onPress={() => navigation.goBack()}
      >
        <Text style={styles.textButton}>Voltar</Text>
      </Pressable>
    </View>
  );
}