import { View, Text, TextInput, Pressable, Alert } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import { useState } from 'react';
import { styles } from '../style';

export default function RegisterScreen({ navigation }) {
  const [email, setEmail] = useState('');
  const [senha, setSenha] = useState('');
  const [confirmarSenha, setConfirmarSenha] = useState('');

  async function handleRegister() {
    if (!email || !senha || !confirmarSenha) {
      Alert.alert('Erro', 'Preencha todos os campos');
      return;
    }
  
    if (senha !== confirmarSenha) {
      Alert.alert('Erro', 'As senhas não coincidem');
      return;
    }
  
    let users = [];
  
    const data = await AsyncStorage.getItem('@users');
  
    if (data) {
      users = JSON.parse(data);
  
      const userExists = users.find(u => u.email === email);
  
      if (userExists) {
        Alert.alert('Erro', 'E-mail já cadastrado');
        return;
      }
    }
  
    users.push({ email, senha });
  
    await AsyncStorage.setItem('@users', JSON.stringify(users));
  
    Alert.alert('Sucesso', 'Usuário cadastrado!');
    navigation.goBack();
  }

  return (
    <View style={styles.container}>
        <Pressable onPress={() => navigation.goBack()}>
        <Text style={{ color: '#22C55E', marginBottom: 20 }}>
            ← Voltar
        </Text>
        </Pressable>
      <Text style={styles.formTitle}>Cadastro</Text>

      <TextInput
        style={styles.formInput}
        placeholder="E-mail"
        onChangeText={setEmail}
      />

      <TextInput
        style={styles.formInput}
        placeholder="Senha"
        secureTextEntry
        onChangeText={setSenha}
      />

        <TextInput
        style={styles.formInput}
        placeholder="Confirmar senha"
        secureTextEntry
        onChangeText={setConfirmarSenha}
        />

      <Pressable style={styles.formButton} onPress={handleRegister}>
        <Text style={styles.textButton}>Cadastrar</Text>
      </Pressable>

      <Pressable style={styles.formButton} onPress={() => navigation.goBack()}>
        <Text style={styles.textButton}>Voltar</Text>
      </Pressable>
    </View>
  );
}