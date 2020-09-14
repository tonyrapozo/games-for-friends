import axios from 'axios';

const instance = axios.create({
  baseURL: 'http://localhost:5000/',
  headers: {
    'content-type': 'application/json',
    'Authorization': `Bearer ${localStorage.getItem('token')}`
  },
});

instance.interceptors.response.use(function (response) {
  return response;
}, function (error) {
  if (401 === error.response.status) {
    localStorage.setItem('token', '');
    window.location = '/login';
  } else {
    return Promise.reject(error);
  }
});

export default instance;