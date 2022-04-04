import styled from 'styled-components';

import { ErrorLabel } from '../../styles/text';

interface Props {
  id: string;
  label: string;
  value: string;
  placeholder: string;
  errorMessage?: string;
  type?: 'text' | 'password';
  onChange: React.ChangeEventHandler<HTMLInputElement>;
}

interface StyleProps {
  error: boolean;
}

const StyledTextField = styled.input<StyleProps>`
  padding: 0.5em;
  -webkit-box-sizing: border-box; /* Safari/Chrome, other WebKit */
  -moz-box-sizing: border-box; /* Firefox, other Gecko */
  box-sizing: border-box; /* Opera/IE 8+ */

  height: 40px;
  width: 100%;
  font-size: 1em;
  border-radius: 3px;

  border: ${(props) =>
    props.error
      ? `1px solid ${props.theme.palette.error.main}`
      : `1px solid ${props.theme.palette.neutral.main}`};

  &:hover {
    border: 1px solid ${(props) => props.theme.palette.neutral.dark};
  }

  &:focus {
    outline: none !important;
    border: 1px solid ${(props) => props.theme.palette.neutral.dark};
  }
`;

const Label = styled.div`
  font-size: 0.85rem;
`;

const TextField = ({
  id,
  value,
  label,
  onChange,
  errorMessage,
  type = 'text',
  ...rest
}: Props) => {
  return (
    <>
      <Label>{label}</Label>
      <StyledTextField
        id={id}
        type={type}
        value={value}
        onChange={onChange}
        error={!!errorMessage}
        {...rest}
      />
      <ErrorLabel id={`${id}-error`}>{errorMessage}</ErrorLabel>
    </>
  );
};

export default TextField;
