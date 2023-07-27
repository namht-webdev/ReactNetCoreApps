import React, { createContext, useContext, useState } from 'react';
import { User } from '../../interfaces';

interface AuthContextProps {
  authUser?: User | null;
  setAuthUser?: (authUser: User) => void;
  userLogin?: boolean;
  setUserLogin?: (isLogin: boolean) => void;
}

const isLoggin = document.cookie
  .split(';')
  .find((cookie) => cookie.trim().startsWith('token='))
  ? true
  : false;
export const AuthContext = createContext<AuthContextProps>({
  authUser: null,
  setAuthUser: (authUser: User | null) => {},
  userLogin: isLoggin,
  setUserLogin: (isLogin: boolean) => {},
});

interface AuthorizationProps {
  children?: JSX.Element;
}
export const Authorization = ({ children }: AuthorizationProps) => {
  const [authUser, setAuthUser] = useState<User | null>(null);
  const [userLogin, setUserLogin] = useState<boolean>(isLoggin);

  return (
    <AuthContext.Provider
      value={{
        authUser,
        setAuthUser,
        userLogin,
        setUserLogin,
      }}
    >
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => {
  return useContext(AuthContext);
};
