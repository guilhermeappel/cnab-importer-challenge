import { useState } from 'react';
import { useNavigate } from 'react-router-dom';

import { Button } from '../../components/buttons';
import { TextField } from '../../components/inputs';
import { CircularProgress } from '../../components/feedbacks';

import { UserRegister } from './../../models/user';
import { Column, Grid, Row } from '../../styles/grid';

import { register } from '../../api/services/user';

interface UserErrors {
  username: string[];
  password: string[];
  passwordConfirmation: string[];
}

const initialUser: UserRegister = {
  username: '',
  password: '',
  passwordConfirmation: '',
};

const initialUserErrors: UserErrors = {
  username: [],
  password: [],
  passwordConfirmation: [],
};

const Register = () => {
  const navigate = useNavigate();

  const [loading, setLoading] = useState(false);

  const [user, setUser] = useState(initialUser);
  const [errors, setErrors] = useState(initialUserErrors);

  const handleChange = (key: keyof UserRegister, value: string) => {
    setErrors(initialUserErrors);
    setUser({ ...user, [key]: value });
  };

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    setLoading(true);

    try {
      await register(user);
      navigate('/login');
    } catch (error: any) {
      if (error.response && error.response.status === 400) {
        setErrors(error.response.data.errors as UserErrors);
      }
    }

    setLoading(false);
  };

  return (
    <form onSubmit={handleSubmit}>
      <Grid>
        <Row>
          <Column size={1}>
            <TextField
              id='username'
              placeholder='Enter your username'
              label='Username'
              value={user.username}
              errorMessage={errors.username?.[0]}
              onChange={(e) => handleChange('username', e.currentTarget.value)}
            />
          </Column>
        </Row>

        <Row>
          <Column size={1}>
            <TextField
              id='password'
              placeholder='Enter your password'
              label='Password'
              type='password'
              value={user.password}
              errorMessage={errors.password?.[0]}
              onChange={(e) => handleChange('password', e.currentTarget.value)}
            />
          </Column>
        </Row>

        <Row>
          <Column size={1}>
            <TextField
              id='passwordConfirmation'
              placeholder='Enter your password confirmation'
              label='Password Confirmation'
              type='password'
              value={user.passwordConfirmation}
              errorMessage={errors.passwordConfirmation?.[0]}
              onChange={(e) =>
                handleChange('passwordConfirmation', e.currentTarget.value)
              }
            />
          </Column>
        </Row>

        <Row>
          <Column size={1}>
            <Button id='register' type='submit'>
              REGISTER
            </Button>
          </Column>
        </Row>
      </Grid>

      {loading && <CircularProgress />}
    </form>
  );
};

export default Register;
