import styled from 'styled-components';

interface Props {
  label: string;
  value: string;
  onChange: React.ChangeEventHandler<HTMLInputElement>;
  placeholder: string;
  helperText?: string;
  type?: 'text' | 'password';
}

const StyledTextField = styled.input``;

const TextField = ({ value, onChange, type = 'text', ...rest }: Props) => {
  return (
    <StyledTextField value={value} onChange={onChange} type={type} {...rest} />
  );
};

export default TextField;
