import api from '../axios';
import { StoreTransaction } from '../../models/transaction';

export const upload = async () => {
  return await api.post<{ ignoredLines: string[] }>('transactions/upload');
};

export const list = async () => {
  return await api.get<StoreTransaction[]>('transactions');
};
