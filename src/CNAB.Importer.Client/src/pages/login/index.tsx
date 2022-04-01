import { useState } from 'react';

import { Button } from '../../components/buttons';
import { TextField } from '../../components/inputs';

interface State {
  username: string;
  password: string;
}

const initialState: State = {
  username: '',
  password: '',
};

const Login = () => {
  const [state, setState] = useState(initialState);

  const handleChange = (key: keyof State, value: string) => {
    setState({ ...state, [key]: value });
  };

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
  };

  return (
    <form onSubmit={handleSubmit}>
      <TextField
        placeholder='Enter your username'
        label='Username'
        value={state.username}
        onChange={(e) => handleChange('username', e.currentTarget.value)}
      />

      <TextField
        placeholder='Enter your password'
        label='Password'
        type='password'
        value={state.password}
        onChange={(e) => handleChange('password', e.currentTarget.value)}
      />

      <Button type='submit'>LOGIN</Button>
    </form>
  );
};

export default Login;
