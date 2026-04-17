import { View, Text, TextInput, Pressable, Alert } from 'react-native';
import { useState } from 'react';
import { criarProduto } from '../services/productService';
import { styles } from '../style';

export default function CreateProductScreen({ navigation }) {
  const [nome, setNome] = useState('');
  const [descricao, setDescricao] = useState('');
  const [marca, setMarca] = useState('');
  const [codigoBarras, setCodigoBarras] = useState('');

  async function handleCreateProduct() {
    try {
      if (!nome || !marca || !codigoBarras) {
        Alert.alert('Erro', 'Preencha os campos obrigatórios');
        return;
      }

      const novoProduto = {
        nome,
        descricao,
        marca,
        codigoBarras,
        categoriaId: 'COLE_AQUI_O_GUID_DA_CATEGORIA_FIXA'
      };

      await criarProduto(novoProduto);

      Alert.alert('Sucesso', 'Produto criado com sucesso');
      navigation.goBack();
    } catch (error) {
      console.error(error);
      Alert.alert('Erro', 'Não foi possível criar o produto');
    }
  }

  return (
    <View style={styles.container}>
      <Text style={styles.formTitle}>Novo Produto</Text>

      <TextInput
        style={styles.formInput}
        placeholder="Nome"
        value={nome}
        onChangeText={setNome}
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

      <Pressable style={styles.formButton} onPress={handleCreateProduct}>
        <Text style={styles.textButton}>Salvar Produto</Text>
      </Pressable>
    </View>
  );
}