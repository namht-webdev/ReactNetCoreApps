import React, { useEffect, useMemo, useState } from 'react';
import { Form, Values, mustBeEmail, required } from '../Context/Form';
import { Field, Option } from '../Context/Field';
import { ApiRequest, DataResponse, useAppDispatch } from '../../reducers';
import { addNew } from '../../reducers/dataSlice';
import { sex } from '../../utils/utilsData';
import axios from 'axios';
import { DEFAULT_API_URL } from '../../api/api';
import { Department, Level, Role } from '../../interfaces';
import { Location } from '../Location';
export const CreateUser = () => {
  const dispatch = useAppDispatch();
  const [messageReturn, setMessage] = useState('');
  const [roles, setRoles] = useState<Option[] | []>([]);
  const [departments, setDepartments] = useState<Option[] | []>([]);
  const [levels, setLevels] = useState<Option[] | []>([]);

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

  useEffect(() => {
    const doGetCompanyInfo = async () => {
      const rolesResponse = (await axios.get(`${DEFAULT_API_URL}/role`))
        .data as DataResponse;
      const departmentsResponse = (
        await axios.get(`${DEFAULT_API_URL}/department`)
      ).data as DataResponse;
      const levelsResponse = (await axios.get(`${DEFAULT_API_URL}/level`))
        .data as DataResponse;
      const roleList = rolesResponse.data as Role[];
      const departmentList = departmentsResponse.data as Department[];
      const levelList = levelsResponse.data as Level[];
      const roleOptions: Option[] = roleList.map((role) => {
        return {
          name: role.role_name,
          value: role.role_id,
        };
      });
      const departmentOptions: Option[] = departmentList.map((department) => {
        return {
          name: department.department_name,
          value: department.department_id,
        };
      });
      const levelOptions: Option[] = levelList.map((level) => {
        return {
          name: level.level_name,
          value: level.level_id,
        };
      });
      setRoles(roleOptions);
      setDepartments(departmentOptions);
      setLevels(levelOptions);
    };

    doGetCompanyInfo();
  }, []);
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
        <div className="grid md:grid-cols-3 md:gap-6">
          <Field
            name="role_id"
            label="Vai trò"
            type="Select"
            optionData={roles}
          ></Field>
          <Field
            name="department_id"
            label="Bộ phận"
            type="Select"
            optionData={departments}
          ></Field>
          <Field
            name="level_id"
            label="Cấp"
            type="Select"
            optionData={levels}
          ></Field>
        </div>
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
