import React, { useState } from 'react';
import { Form, Values, mustBeNumber, required } from '../Context/Form';
import { Field } from '../Context/Field';
import { ApiRequest, DataResponse, useAppDispatch } from '../../reducers';
import { addNew } from '../../reducers/dataSlice';

export const CreateDepartment = () => {
  const dispatch = useAppDispatch();
  const [messageReturn, setMessage] = useState('');
  const handleSubmit = async (department: Values) => {
    const req: ApiRequest = {
      route: 'department',
      title: 'department',
      data: department,
    };
    const response = await dispatch(addNew(req));
    const { success, message } = response.payload as DataResponse;
    setMessage(message);
    return { success };
  };
  return (
    <div>
      <p className="py-10 text-center font-bold text-slate-500">
        THÊM MỚI VAI TRÒ
      </p>
      <Form
        submitCaption="Thêm"
        onSubmit={handleSubmit}
        validationRules={{
          department_id: [{ validator: required }],
          department_name: [{ validator: required }],
          floor: [{ validator: required }, { validator: mustBeNumber }],
        }}
        failureMessage={messageReturn}
        successMessage={messageReturn}
      >
        <div className="grid md:grid-cols-3 md:gap-6">
          <Field name="department_id" label="Mã phòng ban"></Field>
          <Field name="department_name" label="Tên phòng ban"></Field>
          <Field name="floor" label="Tầng"></Field>
        </div>
      </Form>
    </div>
  );
};
