import React, { useState } from 'react';
import { Form, Values, required } from '../Context/Form';
import { Field } from '../Context/Field';
import { DataResponse, useAppDispatch } from '../../reducers';
import { addNew } from '../../reducers/roleSlice';
import { Role } from '../../interfaces/Role';

export const CreateRole = () => {
  const dispatch = useAppDispatch();
  const [messageReturn, setMessage] = useState('');
  const handleSubmit = async (role: Values) => {
    const response = await dispatch(addNew(role as Role));
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
          role_id: [{ validator: required }],
          role_name: [{ validator: required }],
        }}
        failureMessage={messageReturn}
        successMessage={messageReturn}
      >
        <div className="grid md:grid-cols-2 md:gap-6">
          <Field name="role_id" label="Mã vai trò"></Field>
          <Field name="role_name" label="Tên vai trò"></Field>
        </div>
      </Form>
    </div>
  );
};
