export interface StoreTransaction {
  storeName: string;
  totalAmount: number;
  transactions: Transaction[];
}

export interface Transaction {
  type: TransactionType;
  date: Date;
  value: number;
  document: string;
  card: string;
  hour: string;
  storeOwnerName: string;
  storeName: string;
}

export enum TransactionType {
  debit = 1,
  boleto = 2,
  financing = 3,
  credit = 4,
  loanReceipt = 5,
  sales = 6,
  tedReceipt = 7,
  docReceipt = 8,
  rent = 9,
}
