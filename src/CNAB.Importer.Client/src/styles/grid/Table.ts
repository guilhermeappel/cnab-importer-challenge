import styled from 'styled-components';

export const Table = styled.ul`
  margin: 0;
  padding: 0;

  li {
    border-radius: 3px;
    padding: 25px 30px;
    display: flex;
    justify-content: space-between;
    margin-bottom: 15px;
  }
`;

export const TableHeader = styled.li`
  background-color: ${(props) => props.theme.palette.neutral.main};
  color: ${(props) => props.theme.palette.neutral.light};
  text-transform: uppercase;
  letter-spacing: 0.03em;
  font-size: 14px;
`;

export const TableRow = styled.li`
  background-color: ${(props) => props.theme.palette.primary.light};
  box-shadow: 0px 0px 9px 0px rgba(0, 0, 0, 0.1);
`;
