import React, {
  ChangeEvent,
  Fragment,
  useEffect,
  useMemo,
  useState,
} from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { ApiRequest, DataResponse, useAppDispatch } from '../../reducers';
import { User } from '../../interfaces';
import { addNew, getOne, update } from '../../reducers/dataSlice';
import { Form, Values, mustBeEmail, required } from '../Context/Form';
import { Field } from '../Context/Field';
import { gender } from '../../utils/utilsData';
import { CompanyInfo } from '../CompanyInfo';
import { Location } from '../Location';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faSpinner } from '@fortawesome/free-solid-svg-icons';
import axios from 'axios';
import { DEFAULT_API_URL } from '../../api/api';
import { PageTitle } from '../PageTitle';
export const UserAction = () => {
  const { user_id } = useParams();
  const dispatch = useAppDispatch();
  const initialValues = useMemo(() => {
    return {
      birth_date: new Date().toISOString(),
      date_start: new Date().toISOString(),
      date_end: new Date().toISOString(),
      is_deleted: false,
      password_hash: '11111111',
    };
  }, []);
  const [user, setUser] = useState<User | null>(null);
  const [isLoading, setIsLoading] = useState(true);
  const navigate = useNavigate();
  const [selectedImage, setSelectedImage] = useState<
    ArrayBuffer | null | string
  >(null);
  const [imageUpload, setImageUpload] = useState<File | null>(null);
  const req: ApiRequest = useMemo(() => {
    return {
      title: 'user',
      route: 'user',
      id: user_id,
    };
  }, [user_id]);
  useEffect(() => {
    const doGetUser = async () => {
      const response = await dispatch(getOne(req!));
      const { success, data } = response.payload as DataResponse;
      if (success) {
        setUser(data);
        setIsLoading(false);
      } else navigate(`/notfound`);
    };
    if (user_id) doGetUser();
  }, [dispatch, user_id, navigate, req]);

  const [messageReturn, setMessage] = useState('');
  const handleSubmit = async (user: Values) => {
    const actReq: ApiRequest = {
      ...req,
      data: user,
    };
    const response = user_id
      ? await dispatch(update(actReq))
      : await dispatch(addNew(actReq));
    const { success, message } = response.payload as DataResponse;
    if (imageUpload && success) {
      try {
        const formData = new FormData();
        formData.append('fileUpload', imageUpload);
        await axios.post<{ success: boolean }>(
          `${DEFAULT_API_URL}/user/upload?userId=${
            user_id || user.user_id
          }&isCreate=${user_id ? false : true}`,
          formData,
        );
        setImageUpload(null);
      } catch (error) {
        alert('Có lỗi xảy ra trong quá trình thực hiện');
      }
    }
    setMessage(message);
    alert(message);
    return { success, redirectUrl: '/user' };
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
    }
    event.target.value = '';
  };

  const title = user ? 'CẬP NHẬT' : 'THÊM';
  return (
    <div className=" h-screen overflow-y-scroll">
      <PageTitle title={`${title} NGƯỜI DÙNG`} />
      {isLoading && user_id ? (
        <div className="pl-60">
          <FontAwesomeIcon icon={faSpinner} spin />
        </div>
      ) : (
        <Fragment>
          <div className="px-10 text-lg pb-3">
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
                <img
                  src={
                    imageUpload !== null
                      ? (selectedImage as string)
                      : `/uploads/${user?.avatar ? user.avatar : 'avatar.jpg'}`
                  }
                  alt="Selected"
                  className="object-cover w-28 h-28 rounded-full"
                />
              </label>
            </div>
          </div>
          <Form
            submitCaption={title}
            onSubmit={handleSubmit}
            validationRules={{
              user_id: [{ validator: required }],
              user_name: [{ validator: required }],
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
            initialValues={user || initialValues}
          >
            <div className="grid md:grid-cols-3 md:gap-6">
              <Field name="user_id" label="Mã người dùng"></Field>
              <Field name="user_name" label="Tên người dùng"></Field>
              <Field
                name="gender"
                label="Giới tính"
                type="Select"
                optionData={gender}
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
                name="date_start"
                label="Ngày chính thức"
                type="Date"
              ></Field>
              <Field name="date_end" label="Ngày nghỉ" type="Date"></Field>
            </div>
            <CompanyInfo />
            <Location ward_id={user?.ward_id} />
            <Field name="is_deleted" type="Hidden" isDisabled></Field>
          </Form>
        </Fragment>
      )}
    </div>
  );
};
