import React, { useEffect, useState } from 'react';
import { Field } from '../Context/Field';
import {
  Form,
  Values,
  minLength,
  mustBeEmail,
  required,
} from '../Context/Form';
import { useAuth } from '../Context/Authorization';
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
  const { userLogin, setUserLogin, setAuthUser } = useAuth();
  const [isLoading, setIsLoading] = useState(false);
  const navigate = useNavigate();
  const [failMessage, setFailMessage] = useState('');
  const initialValues = {
    email: localStorage.getItem('loginEmail') || '',
    password: localStorage.getItem('loginPassword') || '',
  };
  const handleLogin = async (values: Values) => {
    try {
      setIsLoading(true);
      const response = await axios.post<UserLoginResponse>(
        `${DEFAULT_API_URL}/login`,
        values,
      );

      if (setUserLogin && setAuthUser && response.data.success) {
        setUserLogin(true);
        setAuthUser(response.data.user!);
        axios.defaults.headers.common['Authorization'] = `Bearer ${response.data
          .token!}`;
        localStorage.setItem('access_token', response.data.token!);
        localStorage.setItem('user', JSON.stringify(response.data.user!));
        navigate('/home');
      } else {
        setFailMessage(response.data.message);
      }
      if (localStorage.getItem('passwordRemember') === '1') {
        localStorage.setItem('loginEmail', values.email);
        localStorage.setItem('loginPassword', values.password);
      } else {
        localStorage.removeItem('loginEmail');
        localStorage.removeItem('loginPassword');
        localStorage.removeItem('passwordRemember');
      }
    } catch (error) {
      if (error instanceof Error && error.message.includes('400')) {
        setFailMessage('Email hoặc password không chính xác');
      } else setFailMessage('Có lỗi xảy ra');
    }
    setIsLoading(false);

    return { success: false };
  };
  useEffect(() => {
    if (userLogin) {
      navigate('/');
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [userLogin]);
  return (
    <div className="h-full bg-slate-800">
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
            isLoading={isLoading}
            initialValues={initialValues || null}
          >
            <Field name="email" label="Email"></Field>
            <Field name="password" label="Mật khẩu" type="Password"></Field>
            <Field
              name="passwordRemember"
              label="Mật khẩu"
              type="Checkbox"
            ></Field>
          </Form>

          <div className="w-2/3 text-right pt-10">
            <span className="text-blue-400 italic hover:text-blue-600 cursor-pointer text-sm">
              Quên mật khẩu?
            </span>
          </div>
        </div>
      </div>
    </div>
  );
};
