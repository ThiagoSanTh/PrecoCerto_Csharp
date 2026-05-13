import { useEffect, useState } from 'react';
import AsyncStorage from '@react-native-async-storage/async-storage';

import UserTabs from './tabUser.routes';
import StoreTabs from './tabStore.routes';

export default function AppRoutes() {
  const [mode, setMode] = useState('user');

  useEffect(() => {
    loadMode();
  }, []);

  async function loadMode() {
    const savedMode = await AsyncStorage.getItem('@userMode');
    if (savedMode) setMode(savedMode);
  }

  if (mode === 'store') {
    return <StoreTabs />;
  }

  return <UserTabs />;
}