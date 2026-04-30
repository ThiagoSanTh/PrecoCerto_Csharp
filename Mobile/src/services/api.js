import axios from 'axios';
import { Platform } from 'react-native';

const LOCALHOST_PC = 'http://localhost:5132/api';
const IP_REDE_LOCAL = 'http://192.168.1.77:5132/api';

const baseURL =
  process.env.EXPO_PUBLIC_API_URL ||
  Platform.select({
    web: LOCALHOST_PC,
    android: IP_REDE_LOCAL,
    ios: IP_REDE_LOCAL,
    default: IP_REDE_LOCAL,
  });

const api = axios.create({
  baseURL,
  timeout: 10000,
  headers: {
    'Content-Type': 'application/json',
  },
});

export default api;