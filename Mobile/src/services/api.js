import axios from 'axios';

const api = axios.create({
  baseURL: process.env.EXPO_PUBLIC_API_URL || 'http://192.168.0.15:5132/api',
  timeout: 10000,
  headers: {
    'Content-Type': 'application/json',
  },
});

export default api;