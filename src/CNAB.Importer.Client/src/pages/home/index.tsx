import { useState } from 'react';
import styled from 'styled-components';

import { CircularProgress } from '../../components/feedbacks';
import UploadFileButton from '../../components/buttons/UploadFileButton';

import { list, upload } from '../../api/services/transaction';

import { Column, Grid, Row } from '../../styles/grid';
import { StoreTransaction, Transaction } from '../../models/transaction';

import { formatDate } from '../../utils/date';
import { currencyFormat } from '../../utils/number';
import { getSignal, TransactionDescription } from '../../utils/transaction';
import { Subtitle, Title } from '../../styles/text';
import { Table, TableHeader, TableRow } from '../../styles/grid/Table';

const ContainerList = styled.div`
  margin-bottom: 40px;
`;

const Home = () => {
  const [loading, setLoading] = useState(false);

  const [storeTransactions, setTransactions] = useState<StoreTransaction[]>([]);

  const handleFileUpload = async (event: React.FormEvent<HTMLInputElement>) => {
    if (!event.currentTarget.files) {
      return;
    }

    setLoading(true);

    try {
      const formData = new FormData();
      formData.append('File', event.currentTarget.files[0]);

      await upload(formData);

      const transactionsList = await list();
      setTransactions(transactionsList);

      (event.target as any).value = ''; // work around for uploading same file
    } catch (error) {
      console.error(error);
    }

    setLoading(false);
  };

  return (
    <Grid>
      <Row>
        <Column size={1}>
          <UploadFileButton onChange={handleFileUpload} />
        </Column>
      </Row>

      {storeTransactions.map(
        ({ storeName, totalAmount, transactions }: StoreTransaction) => (
          <Grid key={storeName}>
            <Row>
              <Column size={1}>
                <Title>{storeName}</Title>
              </Column>
              <Column size={4}>
                <Subtitle>Total: {currencyFormat(totalAmount)}</Subtitle>{' '}
              </Column>
            </Row>

            <ContainerList>
              <Table>
                <TableHeader>
                  <Column size={1}>Date</Column>
                  <Column size={1}>Value</Column>
                  <Column size={1}>Type</Column>
                </TableHeader>
                {transactions.map(
                  ({ date, value, type }: Transaction, index) => (
                    <TableRow key={index}>
                      <Column size={1}>{formatDate(date)}</Column>
                      <Column size={1}>
                        {`${getSignal(type)} ${currencyFormat(value)}`}
                      </Column>
                      <Column size={1}>
                        {TransactionDescription.get(type)}
                      </Column>
                    </TableRow>
                  )
                )}
              </Table>
            </ContainerList>
          </Grid>
        )
      )}

      {loading && <CircularProgress />}
    </Grid>
  );
};

export default Home;
