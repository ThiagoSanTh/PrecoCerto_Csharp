import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import SearchScreen from '../screens/SearchScreen';
import FavoritosScreen from '../screens/FavoritosScreen';
import HistoricoScreen from '../screens/HistoricoScreen';
import UserScreen from '../screens/UserScreen';

const Tab = createBottomTabNavigator();

export default function UserTabs() {
  return (
    <Tab.Navigator screenOptions={{ headerShown: false }}>
      <Tab.Screen name="Buscar" component={SearchScreen} />
      <Tab.Screen name="Favoritos" component={FavoritosScreen} />
      <Tab.Screen name="Histórico" component={HistoricoScreen} />
      <Tab.Screen name="Perfil" component={UserScreen} />
    </Tab.Navigator>
  );
}
