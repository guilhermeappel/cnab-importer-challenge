import axios from 'axios';

const instance = axios.create({
  baseURL: process.env.API_URL || 'http://localhost:7702/api/',
});

instance.interceptors.request.use((request) => {
  const token = JSON.parse(
    sessionStorage.getItem('cnab.user') as string
  )?.token;

  request.headers!['Authorization'] = `Bearer ${token}`;

  return request;
});

instance.interceptors.response.use(
  (response) => response,
  (error) => {
    console.error(error);

    // @TODO - Apply refresh token and/or redirect to login page
    // @TODO - Handle errors 404, 500, etc.

    return Promise.reject(error);
  }
);

export default instance;
