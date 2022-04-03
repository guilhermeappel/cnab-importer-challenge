import styled from 'styled-components';

const ErrorLabel = styled.div`
  font-size: 0.75rem;
  color: ${(props) => props.theme.palette.error.main};
`;

export default ErrorLabel;
