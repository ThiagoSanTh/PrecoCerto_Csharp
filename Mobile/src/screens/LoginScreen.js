import { StatusBar } from 'expo-status-bar';
import { Pressable, Text, View, TextInput, Alert } from 'react-native';
import { styles } from '../style';
import { useState } from 'react';
import AsyncStorage from '@react-native-async-storage/async-storage';

export default function LoginScreen({ navigation }) {
  const [email, setEmail] = useState('');
  const [senha, setSenha] = useState('');

  async function handleLogin() {
    if (!email || !senha) {
      Alert.alert('Erro', 'Preencha todos os campos');
      return;
    }

    const data = await AsyncStorage.getItem('@users');

    if (!data) {
      Alert.alert('Erro', 'Nenhum usuário cadastrado');
      return;
    }

    const users = JSON.parse(data);

    const user = users.find(
      u => u.email === email && u.senha === senha
    );

    if (!user) {
      Alert.alert(
        'Usuário não encontrado',
        'Deseja criar uma conta?',
        [
          { text: 'Cancelar' },
          { text: 'Cadastrar', onPress: () => navigation.navigate('Cadastro') }
        ]
      );
      return;
    }

    // ✅ Login OK
    await AsyncStorage.setItem('@loggedUser', JSON.stringify(user));

    navigation.replace('Home');
  }

  return (
    <View style={styles.container}>
      <Text style={styles.formTitle}>Login</Text>

      <TextInput
        style={styles.formInput}
        placeholder="Informe o email"
        autoCapitalize="none"
        onChangeText={setEmail}
      />

      <TextInput
        style={styles.formInput}
        placeholder="Informe a senha"
        secureTextEntry
        onChangeText={setSenha}
      />

      <Pressable style={styles.formButton} onPress={handleLogin}>
        <Text style={styles.textButton}>Logar</Text>
      </Pressable>

      <View style={styles.subContainer}>
        <Pressable
          onPress={() => navigation.navigate('EsqueciSenha')}
          style={styles.subButton}
        >
          <Text style={styles.subTextButton}>
            Esqueci a senha
          </Text>
        </Pressable>

        <Pressable
          onPress={() => navigation.navigate('Cadastro')}
          style={styles.subButton}
        >
          <Text style={styles.subTextButton}>
            Novo usuário
          </Text>
        </Pressable>
      </View>

      <StatusBar style="auto" />
    </View>
  );
}