import React, { useContext, useEffect, useState } from 'react';
import { Form, FormContext, Values, required } from '../Context/Form';
import { Field, Option } from '../Context/Field';
import { ApiRequest, DataResponse, useAppDispatch } from '../../reducers';
import { addNew } from '../../reducers/dataSlice';
import { sex } from '../../utils/utilsData';
import axios from 'axios';
import { DEFAULT_API_URL } from '../../api/api';
import { Department, District, Level, Province, Role } from '../../interfaces';
export const CreateUser = () => {
  const dispatch = useAppDispatch();
  const [messageReturn, setMessage] = useState('');
  const [roles, setRoles] = useState<Option[] | []>([]);
  const [departments, setDepartments] = useState<Option[] | []>([]);
  const [levels, setLevels] = useState<Option[] | []>([]);
  const [provinces, setProvinces] = useState<Option[] | []>([]);
  const [districts, setDistricts] = useState<Option[] | []>([]);
  const [provinceId, setProvinceId] = useState<string>('');
  const address_id = 'Addr'.concat(Date.now().toString());
  let initialValues = {
    birth_date: new Date().toISOString().split('T')[0],
    date_start: new Date().toISOString().split('T')[0],
    date_end: new Date().toISOString().split('T')[0],
    is_deleted: false,
    province_id: '',
  };
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
    const doGetRole = async () => {
      const response = (await axios.get(`${DEFAULT_API_URL}/role`))
        .data as DataResponse;
      const roleList = response.data as Role[];
      const roleOptions: Option[] = [];
      roleList.forEach((role) => {
        roleOptions.push({ name: role.role_name, value: role.role_id });
      });
      setRoles(roleOptions);
    };
    const doGetDepartment = async () => {
      const response = (await axios.get(`${DEFAULT_API_URL}/department`))
        .data as DataResponse;
      const departmentList = response.data as Department[];
      const departmentOptions: Option[] = [];
      departmentList.forEach((department) => {
        departmentOptions.push({
          name: department.department_name,
          value: department.department_id,
        });
      });
      setDepartments(departmentOptions);
    };
    const doGetLevel = async () => {
      const response = (await axios.get(`${DEFAULT_API_URL}/level`))
        .data as DataResponse;
      const levelList = response.data as Level[];
      const levelOptions: Option[] = [];
      levelList.forEach((level) => {
        levelOptions.push({
          name: level.level_name,
          value: level.level_id,
        });
      });
      setLevels(levelOptions);
    };
    const doGetProvince = async () => {
      const response = (await axios.get(`${DEFAULT_API_URL}/location/province`))
        .data as DataResponse;
      const provinceList = response.data as Province[];
      const provinceOptions: Option[] = provinceList.map((province) => {
        return { name: province.province_name, value: province.province_id };
      });
      setProvinces(provinceOptions);
    };
    doGetProvince();
    doGetRole();
    doGetDepartment();
    doGetLevel();
  }, []);

  // useEffect(() => {
  //   const doGetDistrict = async () => {
  //     const response = (
  //       await axios.get(`${DEFAULT_API_URL}/location/district/${provinceId}`)
  //     ).data as DataResponse;
  //     const districtList = response.data as District[];
  //     const districtOptions: Option[] = [];
  //     districtList.forEach((district) => {
  //       districtOptions.push({
  //         name: district.district_name,
  //         value: district.district_id,
  //       });
  //     });
  //     setDistricts(districtOptions);
  //   };
  //   if (provinceId) doGetDistrict();
  // }, [provinceId]);

  const handleChangeProvince = async (provinceId: string) => {
    const response = (
      await axios.get(`${DEFAULT_API_URL}/location/district/${provinceId}`)
    ).data as DataResponse;
    const districtList = response.data as District[];
    const districtOptions: Option[] = districtList.map((district) => {
      return { name: district.district_name, value: district.district_id };
    });
    setDistricts(districtOptions);
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
        <div className="grid md:grid-cols-4 md:gap-4">
          <Field
            name="province_id"
            label="Tỉnh/thành phố"
            type="Select"
            optionData={provinces}
          ></Field>
          <Field name="district_id" label="Quận/huyện" type="Select"></Field>
          <Field name="ward_id" label="Phường/xã" type="Select"></Field>
          <Field name="street" label="Số nhà"></Field>
        </div>
        <Field name="is_deleted" type="Hidden" isDisabled></Field>
      </Form>
    </div>
  );
};
