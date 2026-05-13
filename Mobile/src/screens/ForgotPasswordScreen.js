import { View, Text, TextInput, Pressable, Alert } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import { useState } from 'react';
import { styles } from '../style';  

export default function ForgotPasswordScreen({navigation}) {
  const [email, setEmail] = useState('');

  async function handleRecover() {
    const data = await AsyncStorage.getItem('@user');

    if (!data) {
      Alert.alert('Erro', 'Nenhum usuário cadastrado');
      return;
    }

    const user = JSON.parse(data);

    if (user.email === email) {
      Alert.alert('Senha encontrada', `Sua senha é: ${user.senha}`);
    } else {
      Alert.alert('Erro', 'Email não encontrado');
    }
  }

  return (
    <View style={styles.container}>
      <Text style={styles.formTitle}>Recuperar Senha</Text>

      <TextInput
        style={styles.formInput}
        placeholder="Digite seu email"
        onChangeText={setEmail}
      />

      <Pressable style={styles.formButton} onPress={handleRecover}>
        <Text style={styles.textButton}>Recuperar</Text>
      </Pressable>

      <Pressable style={styles.formButton} onPress={() => navigation.goBack()}>
        <Text style={styles.textButton}>Voltar</Text>
      </Pressable>
    </View>
  );
}