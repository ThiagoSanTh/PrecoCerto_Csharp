import { View, Text, TextInput, Pressable, Alert } from 'react-native';
import { useState } from 'react';
import { criarProduto } from '../services/productService';
import { styles } from '../style';

export default function CreateProductScreen({ navigation }) {
  const [nomeProduto, setNomeProduto] = useState('');
  const [descricao, setDescricao] = useState('');
  const [marca, setMarca] = useState('');
  const [codigoBarras, setCodigoBarras] = useState('');
  const [preco, setPreco] = useState('');

  async function handleCreateProduct() {
    try {
      const precoConvertido = Number(preco.replace(',', '.'));

      if (!nomeProduto.trim() || !marca.trim() || !codigoBarras.trim()) {
        Alert.alert('Erro', 'Preencha os campos obrigatórios');
        return;
      }

      if (Number.isNaN(precoConvertido) || precoConvertido <= 0) {
        Alert.alert('Erro', 'Informe um preço válido');
        return;
      }

      const novoProduto = {
        nomeProduto,
        descricao,
        marca,
        codigoBarras,
        preco: precoConvertido
      };

      await criarProduto(novoProduto);

      Alert.alert('Sucesso', 'Produto criado com sucesso');
      navigation.goBack();
    } catch (error) {
      console.error(error?.response?.data || error.message);
      Alert.alert('Erro', 'Não foi possível criar o produto');
    }
  }

  return (
    <View style={styles.container}>
      <Text style={styles.formTitle}>Novo Produto</Text>

      <TextInput
        style={styles.formInput}
        placeholder="Nome"
        value={nomeProduto}
        onChangeText={setNomeProduto}
      />

      <TextInput
        style={styles.formInput}
        placeholder="Descrição"
        value={descricao}
        onChangeText={setDescricao}
      />

      <TextInput
        style={styles.formInput}
        placeholder="Marca"
        value={marca}
        onChangeText={setMarca}
      />

      <TextInput
        style={styles.formInput}
        placeholder="Código de barras"
        value={codigoBarras}
        onChangeText={setCodigoBarras}
      />

      <TextInput
        style={styles.formInput}
        placeholder="Preço"
        value={preco}
        onChangeText={setPreco}
        keyboardType="decimal-pad"
      />

      <Pressable style={styles.formButton} onPress={handleCreateProduct}>
        <Text style={styles.textButton}>Salvar Produto</Text>
      </Pressable>
    </View>
  );
}