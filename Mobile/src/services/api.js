import axios from 'axios';

const api = axios.create({
  //baseURL: 'http://10.0.2.2:5132/api',
  baseURL: 'http://192.168.0.15:5132/api',
});

export default api;