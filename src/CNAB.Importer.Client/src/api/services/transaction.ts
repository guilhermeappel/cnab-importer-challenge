import api from '../axios';
import { StoreTransaction } from '../../models/transaction';

export const upload = async (file: FormData) => {
  return await api.post<{ ignoredLines: string[] }>(
    'transactions/upload',
    file
  );
};

export const list = async () => {
  const { data } = await api.get<StoreTransaction[]>('transactions');

  return data;
};
