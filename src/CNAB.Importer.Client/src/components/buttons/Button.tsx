import styled from 'styled-components';

interface Props {
  children?: React.ReactNode;
  type?: 'button' | 'submit' | 'reset';
}

const StyledButton = styled.button``;

const Button = ({ children, type = 'button' }: Props) => {
  return <StyledButton type={type}>{children}</StyledButton>;
};

export default Button;
