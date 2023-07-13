import React, { useEffect, useMemo, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { ApiRequest, DataResponse, useAppDispatch } from '../../reducers';
import { Department } from '../../interfaces';
import { getOne, update } from '../../reducers/dataSlice';
import { Form, Values, mustBeNumber, required } from '../Context/Form';
import { Field } from '../Context/Field';

export const UpdateDepartment = () => {
  const { department_id } = useParams();
  const dispatch = useAppDispatch();
  const [department, setDepartment] = useState<Department | null>(null);

  const navigate = useNavigate();
  const req: ApiRequest = useMemo(() => {
    return {
      title: 'department',
      route: 'department',
      id: department_id,
    };
  }, [department_id]);
  useEffect(() => {
    const doGetDepartment = async () => {
      const response = await dispatch(getOne(req!));
      const { success, data } = response.payload as DataResponse;
      success === true ? setDepartment(data) : navigate(`/notfound`);
    };
    doGetDepartment();
  }, [dispatch, navigate, req]);

  const [messageReturn, setMessage] = useState('');
  const handleSubmit = async (department: Values) => {
    const updateReq: ApiRequest = {
      ...req,
      data: department,
    };
    const response = await dispatch(update(updateReq));
    const { success, message } = response.payload as DataResponse;
    setMessage(message);
    alert(message);
    return { success, redirectUrl: '/department' };
  };
  return (
    <div>
      <div className="pt-24">
        <Form
          submitCaption="Cập nhật"
          onSubmit={handleSubmit}
          validationRules={{
            department_id: [{ validator: required }],
            department_name: [{ validator: required }],
            floor: [{ validator: required }, { validator: mustBeNumber }],
          }}
          initialValue={department ? department : {}}
          failureMessage={messageReturn}
          successMessage={messageReturn}
        >
          <div className="grid md:grid-cols-3 md:gap-6">
            <Field name="department_id" label="Mã phòng ban" isDisabled></Field>
            <Field name="department_name" label="Tên phòng ban"></Field>
            <Field name="floor" label="Tầng"></Field>
          </div>
        </Form>
      </div>
    </div>
  );
};
