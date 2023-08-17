import React, { createContext, useContext, useState } from 'react';
import { UserVM } from '../../interfaces';
import axios from 'axios';

interface AuthContextProps {
  authUser?: UserVM | null;
  setAuthUser?: (authUser: UserVM) => void;
  userLogin?: boolean;
  setUserLogin?: (isLogin: boolean) => void;
}

const userLogined = sessionStorage.getItem('user');
const access_token = sessionStorage.getItem('access_token');
axios.defaults.headers.common['Authorization'] = `Bearer ${access_token}`;
const isLoggin = userLogined && access_token ? true : false;
export const AuthContext = createContext<AuthContextProps>({
  authUser: userLogined ? (JSON.parse(userLogined) as UserVM) : null,
  setAuthUser: (authUser: UserVM | null) => {},
  userLogin: isLoggin,
  setUserLogin: (isLogin: boolean) => {},
});

interface AuthorizationProps {
  children?: JSX.Element;
}
export const Authorization = ({ children }: AuthorizationProps) => {
  const [authUser, setAuthUser] = useState<UserVM | null>(
    userLogined ? (JSON.parse(userLogined) as UserVM) : null,
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
