import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';

import StoreScreen from '../screens/StoreScreen';
import ProductsScreen from '../screens/ProductsScreen';

const Tab = createBottomTabNavigator();

export default function StoreTabs() {
  return (
    <Tab.Navigator screenOptions={{ headerShown: false }}>
      <Tab.Screen name="Produtos" component={ProductsScreen} />
      <Tab.Screen name="Loja" component={StoreScreen} />
    </Tab.Navigator>
  );
}