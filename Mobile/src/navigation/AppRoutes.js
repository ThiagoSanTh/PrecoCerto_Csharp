import { useEffect, useState } from 'react';
import AsyncStorage from '@react-native-async-storage/async-storage';
import { useAuth } from '../context/AuthContext';
import UserTabs from './tabUser.routes';
import StoreTabs from './tabStore.routes';

export default function AppRoutes() {
  const { session, loading } = useAuth();
  const [mode, setMode] = useState('user');

  useEffect(() => {
    async function loadMode() {
      const saved = await AsyncStorage.getItem('@userMode');
      if (saved) {
        setMode(saved);
      } else if (session?.tipo === 'lojista') {
        setMode('store');
      } else {
        setMode('user');
      }
    }
    loadMode();
  }, [session]);

  if (loading) return null;

  if (session?.tipo === 'lojista' || mode === 'store') {
    return <StoreTabs />;
  }

  return <UserTabs />;
}
