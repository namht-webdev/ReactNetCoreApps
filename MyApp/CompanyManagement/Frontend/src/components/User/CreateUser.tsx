import { Form, Values, mustBeEmail, required } from '../Context/Form';
import { Field } from '../Context/Field';
import { ApiRequest, DataResponse, useAppDispatch } from '../../reducers';
import { addNew } from '../../reducers/dataSlice';
import { gender } from '../../utils/utilsData';
import { Location } from '../Location';
import { CompanyInfo } from '../CompanyInfo';
import { ChangeEvent, useMemo, useState } from 'react';
import { DEFAULT_API_URL } from '../../api/api';
import axios from 'axios';

export const CreateUser = () => {
  const dispatch = useAppDispatch();
  const [messageReturn, setMessage] = useState('');
  const [selectedImage, setSelectedImage] = useState<
    string | ArrayBuffer | null
  >(null);
  const [imageUpload, setImageUpload] = useState<File | null>(null);
  const initialValues = useMemo(() => {
    return {
      birth_date: new Date().toISOString().split('T')[0],
      date_start: new Date().toISOString().split('T')[0],
      date_end: new Date().toISOString().split('T')[0],
      is_deleted: false,
      avatar: Date.now().toString(),
    };
  }, []);
  const handleSubmit = async (user: Values) => {
    const req: ApiRequest = {
      route: 'user',
      title: 'user',
      data: user,
    };
    if (imageUpload) {
      try {
        const formData = new FormData();
        formData.append('fileUpload', imageUpload);
        const resUpload = await axios.post<{ success: boolean }>(
          `${DEFAULT_API_URL}/user/upload?userId=namht`,
          formData,
        );
        if (!resUpload.data.success) setMessage('File lỗi');
        return { success: false };
      } catch (error) {}
    }
    const response = await dispatch(addNew(req));
    const { success, message } = response.payload as DataResponse;
    setMessage(message);
    return { success };
  };

  const handleImageChange = (event: ChangeEvent<HTMLInputElement>) => {
    const file = event.target.files?.[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = () => {
        setSelectedImage(reader.result);
        setImageUpload(file);
      };
      reader.readAsDataURL(file);
      const formData = new FormData();
      formData.append('fileUpload', file);
      axios.post<{ success: boolean }>(
        `${DEFAULT_API_URL}/user/upload`,
        formData,
      );
    }
  };
  return (
    <div>
      <p className="py-10 text-center font-bold text-slate-500">
        THÊM MỚI NGƯỜI DÙNG
      </p>
      <div className="px-10 text-lg">
        <div className="text-center">
          <input
            type="file"
            accept=".jpg, .png"
            onChange={handleImageChange}
            className="hidden"
            name="fileUpload"
            id="fileUpload"
          />
          <label
            htmlFor="fileUpload"
            className="cursor-pointer p-0 inline-block w-auto"
          >
            {selectedImage ? (
              <img
                src={selectedImage as string}
                alt="Selected"
                className="sm:w-40 object-cover sm:h-40 w-28 h-28"
              />
            ) : (
              <div className="sm:w-32 sm:h-32 w-16 h-16 border border-gray-300 flex items-center justify-center">
                <span className="text-gray-400 text-lg">Chọn hình ảnh</span>
              </div>
            )}
          </label>
        </div>
      </div>
      <Form
        submitCaption="Thêm"
        onSubmit={handleSubmit}
        validationRules={{
          user_id: [{ validator: required }],
          full_name: [{ validator: required }],
          password_hash: [{ validator: required }],
          email: [{ validator: required }, { validator: mustBeEmail }],
          phone_number: [{ validator: required }],
          gender: [{ validator: required }],
          salary: [{ validator: required }],
          role_id: [{ validator: required }],
          department_id: [{ validator: required }],
          level_id: [{ validator: required }],
        }}
        failureMessage={messageReturn}
        successMessage={messageReturn}
        initialValues={initialValues}
      >
        <Field name="avatar" type="File"></Field>

        <div className="grid md:grid-cols-3 md:gap-6">
          <Field name="user_id" label="Mã người dùng"></Field>
          <Field name="full_name" label="Tên người dùng"></Field>
          <Field
            name="password_hash"
            label="Mật khẩu đăng nhập"
            type="Password"
          ></Field>
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
            optionData={gender}
          ></Field>
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
