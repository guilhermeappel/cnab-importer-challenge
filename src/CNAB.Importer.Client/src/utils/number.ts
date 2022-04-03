export const currencyFormat = (value: number) => {
  return Number.parseFloat(value.toString()).toFixed(2).replace('.', ',');
};
