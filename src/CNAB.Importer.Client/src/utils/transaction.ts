import { TransactionType } from '../models/transaction';

export const getSignal = (type: TransactionType) => signals[type];

export const TransactionDescription = new Map<number, string>([
  [TransactionType.debit, 'Debit'],
  [TransactionType.boleto, 'Boleto'],
  [TransactionType.financing, 'Financing'],
  [TransactionType.credit, 'Credit'],
  [TransactionType.loanReceipt, 'Loan Receipt'],
  [TransactionType.sales, 'Sales'],
  [TransactionType.tedReceipt, 'TED Receipt'],
  [TransactionType.docReceipt, 'DOC Receipt'],
  [TransactionType.rent, 'Rent'],
]);

const signals = {
  [TransactionType.debit]: '+',
  [TransactionType.boleto]: '-',
  [TransactionType.financing]: '-',
  [TransactionType.credit]: '+',
  [TransactionType.loanReceipt]: '+',
  [TransactionType.sales]: '+',
  [TransactionType.tedReceipt]: '+',
  [TransactionType.docReceipt]: '+',
  [TransactionType.rent]: '-',
};
