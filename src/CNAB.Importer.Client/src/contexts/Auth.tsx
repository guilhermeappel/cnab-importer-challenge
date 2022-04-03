import { createContext, useState, useContext } from 'react';
import { useNavigate, useLocation } from 'react-router-dom';

import { UserAuth, UserCredentials, UserLoginErrors } from './../models/user';
import * as service from '../api/services/user';

interface Props {
  children?: React.ReactNode;
}

interface ContextData {
  authenticated: boolean;
  errors: UserLoginErrors;
  login: (user: UserCredentials) => Promise<void>;
  logout: () => void;
}

const sessionUser = sessionStorage.getItem('cnab.user');

const initialUserState: UserAuth | undefined = sessionUser
  ? (JSON.parse(sessionUser) as UserAuth)
  : undefined;

const initialUserErrors: UserLoginErrors = {
  username: [],
  password: [],
  invalidLogin: [],
};

const AuthContext = createContext<ContextData>({} as ContextData);
const useAuth = () => useContext(AuthContext);

const AuthProvider = ({ children }: Props) => {
  const navigate = useNavigate();
  const location = useLocation();

  const [user, setUser] = useState<UserAuth | undefined>(initialUserState);
  const [errors, setErrors] = useState<UserLoginErrors>(initialUserErrors);

  const login = async (credentials: UserCredentials) => {
    try {
      const userAuth = await service.login(credentials);
      setUser(userAuth);

      // Send the user back to the page he tried to visit when he was
      // redirected to the login page. Use { replace: true } so we don't create
      // another entry in the history stack for the login page.  This means that
      // when the user get to the protected page and click the back button, he
      // won't end up back on the login page, which is also really nice for the
      // user experience.
      const from = ((location.state as any)?.from?.pathname as string) || '/';
      navigate(from, { replace: true });
    } catch (error: any) {
      if (error.response && error.response.status === 400) {
        setErrors(error.response.data.errors);
      }
    }
  };

  const logout = async () => {
    sessionStorage.removeItem('cnab.user');
    setUser(undefined);
  };

  return (
    <AuthContext.Provider
      value={{
        authenticated: !!user,
        errors,
        login,
        logout,
      }}
    >
      {children}
    </AuthContext.Provider>
  );
};

export { AuthProvider, useAuth };
