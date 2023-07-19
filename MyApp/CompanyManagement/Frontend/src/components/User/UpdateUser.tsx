import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { ApiRequest, DataResponse, useAppDispatch } from '../../reducers';
import { User } from '../../interfaces';
import { getOne, update } from '../../reducers/dataSlice';
import { Form, Values, mustBeEmail, required } from '../Context/Form';
import { Field } from '../Context/Field';
import { sex } from '../../utils/utilsData';
import { CompanyInfo } from '../CompanyInfo';
import { Location } from '../Location';

export const UpdateUser = () => {
  const { user_id } = useParams();
  const dispatch = useAppDispatch();
  // const { isLoading } = useAppSelector((state: RootState) => state.user);
  const [user, setUser] = useState<User | null>(null);
  const navigate = useNavigate();
  useEffect(() => {
    const doGetUser = async () => {
      const req: ApiRequest = {
        title: 'user',
        route: 'user',
        id: user_id,
      };
      const response = await dispatch(getOne(req!));
      const { success, data } = response.payload as DataResponse;
      success === true ? setUser(data) : navigate(`/notfound`);
    };
    doGetUser();
  }, [dispatch, user_id, navigate]);

  const [messageReturn, setMessage] = useState('');
  const handleSubmit = async (user: Values) => {
    const req: ApiRequest = {
      title: 'user',
      route: 'user',
      id: user_id,
      data: user,
    };
    const response = await dispatch(update(req));
    const { success, message } = response.payload as DataResponse;
    setMessage(message);
    alert(message);
    return { success, redirectUrl: '/user' };
  };
  return (
    <div>
      <div className="pt-24">
        <Form
          submitCaption="Cập nhật"
          onSubmit={handleSubmit}
          validationRules={{
            user_id: [{ validator: required }],
            full_name: [{ validator: required }],
            email: [{ validator: required }, { validator: mustBeEmail }],
            phone_number: [{ validator: required }],
          }}
          failureMessage={messageReturn}
          successMessage={messageReturn}
          initialValues={user ? user : {}}
        >
          <div className="grid md:grid-cols-3 md:gap-6">
            <Field name="user_id" label="Mã người dùng"></Field>
            <Field name="full_name" label="Tên người dùng"></Field>
            <Field name="password_hash" label="Mật khẩu đăng nhập"></Field>
          </div>
          <div className="grid md:grid-cols-3 md:gap-6">
            <Field name="email" label="Địa chỉ email"></Field>
            <Field name="phone_number" label="SĐT"></Field>
            <Field name="salary" label="Lương"></Field>
          </div>
          <div className="grid md:grid-cols-3 md:gap-6">
            <Field name="birth_date" label="Ngày sinh" type="Date"></Field>
            <Field
              name="gender"
              label="Giới tính"
              type="Select"
              optionData={sex}
            ></Field>
            <Field name="avatar" label="Hình ảnh"></Field>
          </div>
          <CompanyInfo />
          <div className="grid md:grid-cols-2 md:gap-6">
            <Field
              name="date_start"
              label="Ngày chính thức"
              type="Date"
            ></Field>
            <Field name="date_end" label="Ngày nghỉ" type="Date"></Field>
          </div>
          <Location />
          <Field name="is_deleted" type="Hidden" isDisabled></Field>
        </Form>
      </div>
    </div>
  );
};
