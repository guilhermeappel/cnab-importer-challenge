import styled from 'styled-components';

interface Props {
  size?: number;
}

const Column = styled.div<Props>`
  flex: ${(props) => props.size || 'none'};
`;

export default Column;
