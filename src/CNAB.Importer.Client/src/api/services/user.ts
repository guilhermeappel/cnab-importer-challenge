import api from '../axios';
import { UserAuth, UserCredentials, UserRegister } from '../../models/user';

export const login = async (user: UserCredentials): Promise<UserAuth> => {
  const { data } = await api.post<UserAuth>('users/authenticate', user);

  sessionStorage.setItem('cnab.user', JSON.stringify(data));

  return data;
};

export const register = async (user: UserRegister) => {
  return await api.post('users/register', user);
};
