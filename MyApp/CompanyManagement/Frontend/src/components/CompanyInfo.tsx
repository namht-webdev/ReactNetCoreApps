import React, { useEffect, useState } from 'react';
import { Field, Option } from './Context/Field';
import axios from 'axios';
import { DataResponse } from '../reducers';
import { DEFAULT_API_URL } from '../api/api';
import { Department, Level, Role } from '../interfaces';

export const CompanyInfo = () => {
  const [roles, setRoles] = useState<Option[] | []>([]);
  const [departments, setDepartments] = useState<Option[] | []>([]);
  const [levels, setLevels] = useState<Option[] | []>([]);
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
  );
};
