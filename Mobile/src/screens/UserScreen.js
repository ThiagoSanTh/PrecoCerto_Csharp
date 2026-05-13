import { View, Text, TextInput, Pressable, Alert } from 'react-native';
import { styles } from '../style';
import { useState, useEffect } from 'react';
import AsyncStorage from '@react-native-async-storage/async-storage';

export default function UserScreen({ navigation }) {
  const [email, setEmail] = useState('');
  const [senha, setSenha] = useState('');
  const [hasStore, setHasStore] = useState(false);

  useEffect(() => {
    loadUser();
    checkStore();
  }, []);

  async function loadUser() {
    const data = await AsyncStorage.getItem('@loggedUser');

    if (data) {
      const user = JSON.parse(data);
      setEmail(user.email);
      setSenha(user.senha);
    }
  }

  async function checkStore() {
    const data = await AsyncStorage.getItem('@lojas');

    if (data) {
      const lojas = JSON.parse(data);
      if (lojas.length > 0) {
        setHasStore(true);
      }
    }
  }

  async function handleUpdate() {
    if (!email || !senha) {
      Alert.alert('Erro', 'Preencha os campos');
      return;
    }

    const data = await AsyncStorage.getItem('@users');

    if (!data) {
      Alert.alert('Erro', 'Usuários não encontrados');
      return;
    }

    let users = JSON.parse(data);

    const loggedData = await AsyncStorage.getItem('@loggedUser');
    const loggedUser = JSON.parse(loggedData);

    const emailExists = users.find(
      u => u.email === email && u.email !== loggedUser.email
    );

    if (emailExists) {
      Alert.alert('Erro', 'Este e-mail já está em uso');
      return;
    }

    users = users.map(user => {
      if (user.email === loggedUser.email) {
        return { email, senha };
      }
      return user;
    });

    await AsyncStorage.setItem('@users', JSON.stringify(users));

    const updatedUser = { email, senha };
    await AsyncStorage.setItem('@loggedUser', JSON.stringify(updatedUser));

    Alert.alert('Sucesso', 'Dados atualizados!');
  }

  async function handleLogout() {
    await AsyncStorage.removeItem('@loggedUser');
    navigation.replace('Login');
  }

  async function goToStore() {
    await AsyncStorage.setItem('@userMode', 'store');
    navigation.replace('Home');
  }

  return (
    <View style={styles.container}>
      <Text style={styles.formTitle}>Meu Perfil 👤</Text>

      <TextInput
        style={styles.formInput}
        value={email}
        onChangeText={setEmail}
        placeholder="Email"
      />

      <TextInput
        style={styles.formInput}
        value={senha}
        secureTextEntry
        onChangeText={setSenha}
        placeholder="Senha"
      />

      <Pressable style={styles.formButton} onPress={handleUpdate}>
        <Text style={styles.textButton}>Atualizar Dados</Text>
      </Pressable>

      {!hasStore && (
        <>
          <Text style={{ color: '#fff', marginTop: 30 }}>
            Quer começar a vender?
          </Text>

          <Pressable
            style={styles.formButton}
            onPress={() => navigation.navigate('CreateStore')}
          >
            <Text style={styles.textButton}>Criar Loja 🏪</Text>
          </Pressable>
        </>
      )}

      {hasStore && (
        <Pressable style={styles.formButton} onPress={goToStore}>
          <Text style={styles.textButton}>Ir para Loja 🏪</Text>
        </Pressable>
      )}

      <Pressable style={styles.formButton} onPress={handleLogout}>
        <Text style={styles.textButton}>Sair</Text>
      </Pressable>
    </View>
  );
}