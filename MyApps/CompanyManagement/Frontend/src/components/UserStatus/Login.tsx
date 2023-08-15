import React, { useContext, useEffect, useState } from 'react';
import { Field } from '../Context/Field';
import {
  Form,
  Values,
  minLength,
  mustBeEmail,
  required,
} from '../Context/Form';
import { AuthContext } from '../Context/Authorization';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import { UserVM } from '../../interfaces';
import { DEFAULT_API_URL } from '../../api/api';

interface UserLoginResponse {
  user?: UserVM;
  success: boolean;
  message: string;
  token?: string;
}

export const Login = () => {
  const { userLogin, setUserLogin, setAuthUser } = useContext(AuthContext);
  const navigate = useNavigate();
  const [failMessage, setFailMessage] = useState('');
  const handleLogin = async (values: Values) => {
    try {
      const response = await axios.post<UserLoginResponse>(
        `${DEFAULT_API_URL}/login`,
        values,
      );

      if (setUserLogin && setAuthUser && response.data.success) {
        setUserLogin(true);
        setAuthUser(response.data.user!);
        axios.defaults.headers.common['Authorization'] = `Bearer ${response.data
          .token!}`;
        sessionStorage.setItem('access_token', response.data.token!);
        sessionStorage.setItem('user', JSON.stringify(response.data.user!));
        navigate('/');
      } else {
        setFailMessage(response.data.message);
      }
    } catch (error) {
      if (error instanceof Error && error.message.includes('400')) {
        setFailMessage('Email hoặc password không chính xác');
      } else setFailMessage('Có lỗi xảy ra');
    }
    return { success: false };
  };
  useEffect(() => {
    if (userLogin) {
      navigate('/');
    }
  }, [userLogin]);

  return (
    <div className="h-full bg-slate-200">
      <div className="top-1/3 relative py-10 sm:w-3/4 lg:w-2/3 mx-auto">
        <div className="p-5">
          <Form
            validationRules={{
              email: [{ validator: required }, { validator: mustBeEmail }],
              password: [
                { validator: required },
                { validator: minLength, args: 8 },
              ],
            }}
            onSubmit={handleLogin}
            submitCaption="Đăng nhập"
            failureMessage={failMessage}
          >
            <Field name="email" label="Email"></Field>
            <Field name="password" label="Mật khẩu" type="Password"></Field>
          </Form>
          <div className="w-2/3 text-right pt-10">
            {' '}
            <span className="text-blue-400 italic hover:text-blue-600 cursor-pointer text-sm">
              Quên mật khẩu?
            </span>
          </div>
        </div>
      </div>
    </div>
  );
};
