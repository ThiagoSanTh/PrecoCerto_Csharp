import { StatusBar } from 'expo-status-bar';
import { Pressable, Text, View } from 'react-native';
import { styles } from './src/style';
import { TextInput } from 'react-native-web';

export default function App() {
  return (
    <View style={styles.container}>
      <Text style={styles.formTitle}>Login</Text>      
      <TextInput style={styles.formInput}
      placeholder="Informe o email"
      keyboardtipe="email-address"
      autoCapitalize="none"
      autoComplete="email">        
      </TextInput>
      <TextInput style={styles.formInput}
      placeholder="Informe a senha"
      autoCapitalize="none"
      secureTextEntry>
      </TextInput>
      <Pressable style={styles.formButton}>
        <Text style={styles.textButton}>Logar</Text>
      </Pressable>
      <View style={styles.subContainer}>
        <Pressable style={styles.subButton}>
          <Text style={styles.subTextButton}>Esqueci a senha</Text>
        </Pressable>
        <Pressable style={styles.subButton}>
          <Text style={styles.subTextButton}>Novo usuário</Text>
        </Pressable>
      </View>
      <StatusBar style="auto" />
    </View>
  );
}