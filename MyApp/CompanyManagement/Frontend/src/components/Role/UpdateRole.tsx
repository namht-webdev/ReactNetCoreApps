import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { DataResponse, useAppDispatch } from '../../reducers';
import { Role } from '../../interfaces/Role';
import {
  UpdateRolePayload,
  getOne,
  updateRole,
} from '../../reducers/roleSlice';
import { Form, Values, required } from '../Context/Form';
import { Field } from '../Context/Field';

export const UpdateRole = () => {
  const { role_id } = useParams();
  const dispatch = useAppDispatch();
  // const { isLoading } = useAppSelector((state: RootState) => state.role);
  const [role, setRole] = useState<Role | null>(null);
  const navigate = useNavigate();
  useEffect(() => {
    const doGetRole = async () => {
      const response = await dispatch(getOne(role_id!));
      const { success, data } = response.payload as DataResponse;
      success === true ? setRole(data) : navigate(`/notfound`);
    };
    doGetRole();
  }, [dispatch, role_id, navigate]);

  const [messageReturn, setMessage] = useState('');
  const handleSubmit = async (role: Values) => {
    const updateRolePayload: UpdateRolePayload = {
      role_id: role_id!,
      role: role as Role,
    };
    const response = await dispatch(updateRole(updateRolePayload));
    const { success, message } = response.payload as DataResponse;
    setMessage(message);
    alert(message);
    return { success, redirectUrl: '/role' };
  };
  return (
    <div className="pt-24">
      <Form
        submitCaption="Cập nhật"
        onSubmit={handleSubmit}
        validationRules={{
          role_id: [{ validator: required }],
          role_name: [{ validator: required }],
        }}
        initialValue={role ? role : {}}
        failureMessage={messageReturn}
        successMessage={messageReturn}
      >
        <div className="grid md:grid-cols-2 md:gap-6">
          <Field name="role_id" label="Mã vai trò" isDisabled={true} />
          <Field name="role_name" label="Tên vai trò" />
        </div>
      </Form>
    </div>
  );
};
