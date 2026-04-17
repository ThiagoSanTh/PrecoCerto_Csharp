import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';

import SearchScreen from '../screens/SearchScreen';
import UserScreen from '../screens/UserScreen';

const Tab = createBottomTabNavigator();

export default function UserTabs() {
  return (
    <Tab.Navigator screenOptions={{ headerShown: false }}>
      <Tab.Screen name="Buscar" component={SearchScreen} />
      <Tab.Screen name="Usuário" component={UserScreen} />
    </Tab.Navigator>
  );
}