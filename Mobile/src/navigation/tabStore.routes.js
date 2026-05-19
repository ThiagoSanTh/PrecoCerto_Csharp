import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import ProductsScreen from '../screens/ProductsScreen';
import StoreScreen from '../screens/StoreScreen';
import UserScreen from '../screens/UserScreen';

const Tab = createBottomTabNavigator();

export default function StoreTabs() {
  return (
    <Tab.Navigator screenOptions={{ headerShown: false }}>
      <Tab.Screen name="Produtos" component={ProductsScreen} />
      <Tab.Screen name="Loja" component={StoreScreen} />
      <Tab.Screen name="Conta" component={UserScreen} />
    </Tab.Navigator>
  );
}
