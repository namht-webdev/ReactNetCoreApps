import React, { createContext, useContext, useState } from 'react';
import { UserLogined } from '../../interfaces';

interface AuthContextProps {
  authUser?: UserLogined | null;
  setAuthUser?: (authUser: UserLogined) => void;
  userLogin?: boolean;
  setUserLogin?: (isLogin: boolean) => void;
}

const userLogined = sessionStorage.getItem('user');

const isLoggin =
  sessionStorage.getItem('access_token') && sessionStorage.getItem('user')
    ? true
    : false;
export const AuthContext = createContext<AuthContextProps>({
  authUser: userLogined ? (JSON.parse(userLogined) as UserLogined) : null,
  setAuthUser: (authUser: UserLogined | null) => {},
  userLogin: isLoggin,
  setUserLogin: (isLogin: boolean) => {},
});

interface AuthorizationProps {
  children?: JSX.Element;
}
export const Authorization = ({ children }: AuthorizationProps) => {
  const [authUser, setAuthUser] = useState<UserLogined | null>(
    userLogined ? (JSON.parse(userLogined) as UserLogined) : null,
  );
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
