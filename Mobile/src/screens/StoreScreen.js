import { View, Text, Pressable } from 'react-native';
import { styles } from '../style';
import AsyncStorage from '@react-native-async-storage/async-storage';

export default function StoreScreen({ navigation }) {

  async function goToUser() {
    await AsyncStorage.setItem('@userMode', 'user');
    navigation.replace('Home');
  }

  return (
    <View style={styles.container}>
      <Text style={styles.formTitle}>Minha Loja 🏪</Text>

      <Text style={{ color: '#fff', marginBottom: 20 }}>
        Aqui você gerencia sua loja e produtos
      </Text>

      <Pressable style={styles.formButton} onPress={goToUser}>
        <Text style={styles.textButton}>Ir para Usuário 👤</Text>
      </Pressable>
    </View>
  );
}