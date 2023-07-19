import React, { ChangeEvent, useEffect, useState } from 'react';
import { Field, Option } from './Context/Field';
import axios from 'axios';
import { DEFAULT_API_URL } from '../api/api';
import { DataResponse } from '../reducers';
import { District, Province, Ward } from '../interfaces';

export const Location = () => {
  const [provinces, setProvinces] = useState<Option[] | []>([]);
  const [districts, setDistricts] = useState<Option[] | []>([]);
  const [wards, setWards] = useState<Option[] | []>([]);
  const [district, setDistrict] = useState<string>('');

  const handleChangeLocation = async (
    e: ChangeEvent<HTMLSelectElement>,
    isChangeProvince: boolean,
  ) => {
    const value = e.currentTarget.value.toString();
    if (!value) {
      setDistricts([]);
      setWards([]);
      return;
    }
    const route = isChangeProvince ? 'district' : 'ward';
    if (isChangeProvince) setDistrict('');
    const response = (
      await axios.get(`${DEFAULT_API_URL}/location/${route}/${value}`)
    ).data as DataResponse;
    const locationList: District[] | Ward[] = response.data;
    if (isChangeProvince) {
      const districtOptions: Option[] = (locationList as District[]).map(
        (district) => {
          return { name: district.district_name, value: district.district_id };
        },
      );
      setDistricts(districtOptions);
      setWards([]);
    } else {
      const wardOptions: Option[] = (locationList as Ward[]).map((ward) => {
        return { name: ward.ward_name, value: ward.ward_id };
      });
      setDistrict(value);
      setWards(wardOptions);
    }
  };
  useEffect(() => {
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
  }, []);
  return (
    <div className="grid md:grid-cols-4 md:gap-4">
      <div className="relative z-0 w-full mb-6 group">
        <select
          id="province_id"
          className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-md focus:ring-blue-500 focus:border-blue-500 block w-full px-2.5 py-2 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
          onChange={(e) => handleChangeLocation(e, true)}
        >
          <option value={''}>Tỉnh/thành phố</option>
          {provinces?.map((province, idx) => (
            <option key={idx} value={province.value}>
              {province.name}
            </option>
          ))}
        </select>
      </div>
      <div className="relative z-0 w-full mb-6 group">
        <select
          id="district_id"
          className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-md focus:ring-blue-500 focus:border-blue-500 block w-full px-2.5 py-2 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
          onChange={(e) => handleChangeLocation(e, false)}
          value={district}
        >
          <option value={''}>Quận/huyện</option>
          {districts?.map((district, idx) => (
            <option key={idx} value={district.value}>
              {district.name}
            </option>
          ))}
        </select>
      </div>

      <Field
        name="ward_id"
        label="Phường/xã"
        type="Select"
        optionData={wards}
      ></Field>
      <Field name="street" label="Số nhà"></Field>
    </div>
  );
};
