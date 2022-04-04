import { useState } from 'react';

import { Button } from '../../components/buttons';
import { Link } from '../../components/navigations';
import { TextField } from '../../components/inputs';
import { CircularProgress } from '../../components/feedbacks';

import { useAuth } from '../../contexts/Auth';
import { UserCredentials } from '../../models/user';

import { Column, Grid, Row } from '../../styles/grid';
import ErrorLabel from '../../styles/text/ErrorLabel';

const initialUser: UserCredentials = {
  username: '',
  password: '',
};

const Login = () => {
  const { errors, login } = useAuth();

  const [loading, setLoading] = useState(false);
  const [user, setUser] = useState(initialUser);

  const handleChange = (key: keyof UserCredentials, value: string) => {
    setUser({ ...user, [key]: value });
  };

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    setLoading(true);

    await login(user);

    setLoading(false);
  };

  return (
    <form onSubmit={handleSubmit}>
      <Grid>
        <Row>
          <Column size={1}>
            <TextField
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
              placeholder='Enter your password'
              label='Password'
              type='password'
              value={user.password}
              errorMessage={errors.password?.[0]}
              onChange={(e) => handleChange('password', e.currentTarget.value)}
            />
          </Column>
        </Row>

        {errors.invalidLogin.length > 0 && (
          <Row>
            <Column size={1}>
              <ErrorLabel>{errors.invalidLogin[0]}</ErrorLabel>
            </Column>
          </Row>
        )}

        <Row>
          <Column size={1}>
            <Button type='submit'>LOGIN</Button>
          </Column>
        </Row>

        <Row>
          <Column>
            <Link to='/register'>
              Don't have an account? Create one clicking here.
            </Link>
          </Column>
        </Row>
      </Grid>

      {loading && <CircularProgress />}
    </form>
  );
};

export default Login;
