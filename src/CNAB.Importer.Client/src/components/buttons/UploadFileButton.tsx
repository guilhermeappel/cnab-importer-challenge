import { FormEvent, useRef } from 'react';

import Button from './Button';
import { InputFile } from '../../styles/inputs';

interface Props {
  onChange: (event: FormEvent<HTMLInputElement>) => void;
}

const UploadFileButton = ({ onChange }: Props) => {
  const hiddenFileInput = useRef<HTMLInputElement>(null);

  const handleClick = () => {
    if (!hiddenFileInput.current) {
      return;
    }

    hiddenFileInput.current.click();
  };

  return (
    <>
      <Button onClick={handleClick}>UPLOAD</Button>
      <InputFile
        ref={hiddenFileInput}
        type='file'
        id='input-file'
        accept='.txt'
        onChange={onChange}
      />
    </>
  );
};

export default UploadFileButton;
