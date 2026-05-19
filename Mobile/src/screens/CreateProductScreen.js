import { Alert } from 'react-native';
import { useState } from 'react';
import { criarProduto } from '../services/productService';
import { useAuth } from '../context/AuthContext';
import { FormScreen, FormField, PrimaryButton } from '../components/form';

export default function CreateProductScreen({ navigation }) {
  const { session } = useAuth();
  const lojaId = session?.perfil?.lojaId;
  const [nomeProduto, setNomeProduto] = useState('');
  const [descricao, setDescricao] = useState('');
  const [marca, setMarca] = useState('');
  const [codigoBarras, setCodigoBarras] = useState('');
  const [preco, setPreco] = useState('');
  const [loading, setLoading] = useState(false);

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

      if (!lojaId) {
        Alert.alert('Erro', 'Cadastre sua loja antes de criar produtos');
        return;
      }

      setLoading(true);
      await criarProduto({
        nomeProduto,
        descricao,
        marca,
        codigoBarras,
        preco: precoConvertido,
        lojaId,
      });

      Alert.alert('Sucesso', 'Produto criado com sucesso');
      navigation.goBack();
    } catch (error) {
      console.error(error?.response?.data || error.message);
      Alert.alert('Erro', 'Não foi possível criar o produto');
    } finally {
      setLoading(false);
    }
  }

  return (
    <FormScreen
      title="Novo produto"
      subtitle="Produto vinculado à sua loja"
      onBack={() => navigation.goBack()}
      footer={<PrimaryButton label="Salvar produto" onPress={handleCreateProduct} loading={loading} />}
    >
      <FormField label="Nome *" value={nomeProduto} onChangeText={setNomeProduto} autoFocus />
      <FormField label="Descrição" value={descricao} onChangeText={setDescricao} />
      <FormField label="Marca *" value={marca} onChangeText={setMarca} />
      <FormField label="Código de barras *" value={codigoBarras} onChangeText={setCodigoBarras} />
      <FormField
        label="Preço *"
        value={preco}
        onChangeText={setPreco}
        keyboardType="decimal-pad"
      />
    </FormScreen>
  );
}
