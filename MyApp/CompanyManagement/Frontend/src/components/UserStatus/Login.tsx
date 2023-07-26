import React, { useContext, useEffect } from 'react';
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

export const Login = () => {
  const { userLogin, setUserLogin } = useContext(AuthContext);
  const navigate = useNavigate();
  const handleLogin = async (values: Values) => {
    if (setUserLogin) {
      setUserLogin(true);
      localStorage.setItem('login', '123465');
      navigate('/');
    }
    return { success: true };
  };
  useEffect(() => {
    if (userLogin) navigate('/');
  }, [userLogin]);

  return (
    <div className="h-full bg-slate-200">
      <div className="top-1/3 relative py-10 sm:w-3/4 lg:w-2/3 mx-auto">
        <div className="p-5">
          <Form
            validationRules={{
              user_id: [{ validator: required }, { validator: mustBeEmail }],
              password: [
                { validator: required },
                { validator: minLength, args: 8 },
              ],
            }}
            onSubmit={handleLogin}
            submitCaption="Đăng nhập"
          >
            <Field name="user_id" label="Email"></Field>
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
