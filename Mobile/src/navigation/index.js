import { NavigationContainer } from '@react-navigation/native';
import { createNativeStackNavigator } from '@react-navigation/native-stack';

import LoginScreen from '../screens/LoginScreen';
import RegisterScreen from '../screens/RegisterScreen';
import ForgotPasswordScreen from '../screens/ForgotPasswordScreen';
import CreateStoreScreen from '../screens/CreateStoreScreen';
import CreateProductScreen from '../screens/CreateProductScreen';

import AppRoutes from './AppRoutes';

const Stack = createNativeStackNavigator();

export default function Routes() {
  return (
    <NavigationContainer>
      <Stack.Navigator>

        <Stack.Screen name="Login" component={LoginScreen} />
        <Stack.Screen name="Cadastro" component={RegisterScreen} />
        <Stack.Screen name="EsqueciSenha" component={ForgotPasswordScreen} />
        <Stack.Screen name="CreateStore" component={CreateStoreScreen} />
        <Stack.Screen name="CreateProduct" component={CreateProductScreen} />

        <Stack.Screen 
          name="Home" 
          component={AppRoutes}
          options={{ headerShown: false }}
        />

      </Stack.Navigator>
    </NavigationContainer>
  );
}