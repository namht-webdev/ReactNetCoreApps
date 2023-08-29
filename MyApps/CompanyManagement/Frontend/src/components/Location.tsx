import React, { ChangeEvent, useEffect, useState } from 'react';
import { Field, Option } from './Context/Field';
import axios from 'axios';
import { DEFAULT_API_URL } from '../api/api';
import { DataResponse } from '../reducers';
import { District, Location as ILocaiton, Province, Ward } from '../interfaces';

export const Location = ({ ward_id }: { ward_id?: string | null }) => {
  const [provinces, setProvinces] = useState<Option[] | []>([]);
  const [districts, setDistricts] = useState<Option[] | []>([]);
  const [wards, setWards] = useState<Option[] | []>([]);
  const [province, setProvince] = useState<string>('');
  const [district, setDistrict] = useState<string>('');

  const handleChangeLocation = async (
    e: ChangeEvent<HTMLSelectElement>,
    isChangeProvince: boolean,
  ) => {
    const value = e.currentTarget.value;
    if (!value) {
      setDistricts([]);
      setWards([]);
      return;
    }
    const route = isChangeProvince ? 'district' : 'ward';
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
      setDistrict('');
      setProvince(value);
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
    const doGetProvince = async (provinceId?: string) => {
      const response = (await axios.get(`${DEFAULT_API_URL}/location/province`))
        .data as DataResponse;
      const provinceList = response.data as Province[];
      const provinceOptions: Option[] = provinceList.map((province) => {
        return { name: province.province_name, value: province.province_id };
      });
      setProvinces(provinceOptions);
      if (provinceId) setProvince(provinceId);
    };
    const doGetDistrict = async (provinceId: string, districtId: string) => {
      const response = (
        await axios.get(`${DEFAULT_API_URL}/location/district/${provinceId}`)
      ).data as DataResponse;
      const districtList = response.data as District[];
      const districtOptions: Option[] = districtList.map((district) => {
        return { name: district.district_name, value: district.district_id };
      });
      setDistricts(districtOptions);
      setDistrict(districtId);
    };
    const doGetWard = async (districtId: string) => {
      const response = (
        await axios.get(`${DEFAULT_API_URL}/location/ward/${districtId}`)
      ).data as DataResponse;
      const wardList = response.data as Ward[];
      const wardOptions: Option[] = wardList.map((ward) => {
        return { name: ward.ward_name, value: ward.ward_id };
      });
      setWards(wardOptions);
    };
    const doGetLocation = async () => {
      const response = (
        await axios.get(`${DEFAULT_API_URL}/location/ward?wardId=${ward_id}`)
      ).data as DataResponse;
      const location = response.data as ILocaiton;

      doGetProvince(location.province_id);
      doGetDistrict(location.province_id, location.district_id);
      doGetWard(location.district_id);
    };
    ward_id ? doGetLocation() : doGetProvince();
  }, [ward_id]);
  return (
    <div className="grid md:grid-cols-4 md:gap-4">
      <div className="relative z-0 w-full mb-6 group">
        <select
          id="province_id"
          className="border font-bold text-white bg-slate-500 text-sm rounded-md border-slate-400 focus:border-white block w-full px-2.5 py-1.5"
          onChange={(e) => handleChangeLocation(e, true)}
          value={province ? province : ''}
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
          className="border font-bold text-white bg-slate-500 text-sm rounded-md border-slate-400 focus:border-white block w-full px-2.5 py-1.5"
          onChange={(e) => handleChangeLocation(e, false)}
          value={district ? district : ''}
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
