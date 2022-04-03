import styled from 'styled-components';

export interface ButtonProps {
  children?: React.ReactNode;
  type?: 'button' | 'submit' | 'reset';
  onClick?: React.MouseEventHandler<HTMLButtonElement>;
}

const StyledButton = styled.button`
  width: 100%;
  height: 40px;
  font-size: 1em;
  cursor: pointer;
  border-radius: 3px;
  color: ${(props) => props.theme.palette.primary.light};
  background: ${(props) => props.theme.palette.primary.dark};
  border: 1px solid ${(props) => props.theme.palette.primary.main};

  background-position: center;
  transition: 0.5s;

  &:hover {
    background: ${(props) => props.theme.palette.primary.main}
      radial-gradient(
        circle,
        transparent 1%,
        ${(props) => props.theme.palette.primary.main} 1%
      )
      center/15000%;
  }

  &:active {
    background-color: ${(props) => props.theme.palette.primary.light};
    background-size: 100%;
    transition: 0s;
  }
`;

const Button = ({ children, onClick, type = 'button' }: ButtonProps) => {
  return (
    <StyledButton type={type} onClick={onClick}>
      {children}
    </StyledButton>
  );
};

export default Button;
