export interface UserAuth {
  id: number;
  token: string;
}

export interface UserCredentials {
  username: string;
  password: string;
}

export interface UserRegister extends UserCredentials {
  passwordConfirmation: string;
}

export interface UserRegisterErrors {
  username: string[];
  password: string[];
  passwordConfirmation: string[];
}

export interface UserLoginErrors {
  username: string[];
  password: string[];
  invalidLogin: string[];
}
