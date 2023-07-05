import React from 'react';
import { Form, Values, required } from '../Context/Form';
import { Field } from '../Context/Field';
import { RootState, useAppDispatch, useAppSelector } from '../../reducers';
import { addNew } from '../../reducers/roleSlice';
import { Role } from '../../interfaces/Role';

export const CreateRole = () => {
  const dispatch = useAppDispatch();
  const { roles, isLoading, error } = useAppSelector(
    (state: RootState) => state.role,
  );
  const handleSubmit = (role: Values) => {
    if (role.role_id && role.role_name) dispatch(addNew(role as Role));
  };
  return (
    <div>
      <p className="py-10 text-center font-bold text-slate-500">
        DANH SÁCH VAI TRÒ
      </p>
      <Form
        submitCaption="Thêm"
        onSubmit={handleSubmit}
        validationRules={{
          role_id: [{ validator: required }],
          role_name: [{ validator: required }],
        }}
      >
        <div className="grid md:grid-cols-2 md:gap-6">
          <Field name="role_id" label="Mã vai trò"></Field>
          <Field name="role_name" label="Tên vai trò"></Field>
        </div>
      </Form>
    </div>
  );
};
