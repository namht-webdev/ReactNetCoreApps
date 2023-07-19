import { Form, Values, mustBeEmail, required } from '../Context/Form';
import { Field } from '../Context/Field';
import { ApiRequest, DataResponse, useAppDispatch } from '../../reducers';
import { addNew } from '../../reducers/dataSlice';
import { sex } from '../../utils/utilsData';
import { Location } from '../Location';
import { CompanyInfo } from '../CompanyInfo';
import { useMemo, useState } from 'react';
export const CreateUser = () => {
  const dispatch = useAppDispatch();
  const [messageReturn, setMessage] = useState('');

  const initialValues = useMemo(() => {
    return {
      birth_date: new Date().toISOString().split('T')[0],
      date_start: new Date().toISOString().split('T')[0],
      date_end: new Date().toISOString().split('T')[0],
      is_deleted: false,
    };
  }, []);
  const handleSubmit = async (user: Values) => {
    const req: ApiRequest = {
      route: 'user',
      title: 'user',
      data: user,
    };
    const response = await dispatch(addNew(req));
    const { success, message } = response.payload as DataResponse;
    setMessage(message);
    return { success };
  };

  return (
    <div>
      <p className="py-10 text-center font-bold text-slate-500">
        THÊM MỚI NGƯỜI DÙNG
      </p>
      <Form
        submitCaption="Thêm"
        onSubmit={handleSubmit}
        validationRules={{
          user_id: [{ validator: required }],
          full_name: [{ validator: required }],
          email: [{ validator: required }, { validator: mustBeEmail }],
          phone_number: [{ validator: required }],
        }}
        failureMessage={messageReturn}
        successMessage={messageReturn}
        initialValues={initialValues}
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
          <Field name="date_start" label="Ngày chính thức" type="Date"></Field>
          <Field name="date_end" label="Ngày nghỉ" type="Date"></Field>
        </div>
        <Location />
        <Field name="is_deleted" type="Hidden" isDisabled></Field>
      </Form>
    </div>
  );
};
