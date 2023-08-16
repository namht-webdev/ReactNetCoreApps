import React, { useEffect, useMemo, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { ApiRequest, DataResponse, useAppDispatch } from '../../reducers';
import { Role } from '../../interfaces';
import { addNew, getOne, update } from '../../reducers/dataSlice';
import { Form, Values, required } from '../Context/Form';
import { Field } from '../Context/Field';
import { PageTitle } from '../PageTitle';

export const RoleAction = () => {
  const { role_id } = useParams();
  const dispatch = useAppDispatch();
  const [role, setRole] = useState<Role | null>(null);
  const navigate = useNavigate();
  const req: ApiRequest = useMemo(() => {
    return {
      title: 'role',
      route: 'role',
      id: role_id,
    };
  }, [role_id]);
  useEffect(() => {
    const doGetRole = async () => {
      const response = await dispatch(getOne(req!));
      const { success, data } = response.payload as DataResponse;

      success === true ? setRole(data) : navigate(`/notfound`);
    };
    if (role_id) doGetRole();
  }, [dispatch, role_id, navigate, req]);

  const [messageReturn, setMessage] = useState('');
  const handleSubmit = async (role: Values) => {
    const actReq: ApiRequest = {
      ...req,
      data: role,
    };
    const response = role_id
      ? await dispatch(update(actReq))
      : await dispatch(addNew(actReq));
    const { success, message } = response.payload as DataResponse;
    setMessage(message);
    alert(message);
    return { success, redirectUrl: '/role' };
  };
  const title = role_id ? 'CẬP NHẬT' : 'THÊM';
  return (
    <div>
      <PageTitle title={`${title} VAI TRÒ`} />
      <Form
        submitCaption={title}
        onSubmit={handleSubmit}
        validationRules={{
          role_id: [{ validator: required }],
          role_name: [{ validator: required }],
        }}
        initialValues={role ? role : {}}
        failureMessage={messageReturn}
        successMessage={messageReturn}
      >
        <div className="grid md:grid-cols-2 md:gap-6">
          <Field
            name="role_id"
            label="Mã vai trò"
            isDisabled={role_id ? true : false}
          />
          <Field name="role_name" label="Tên vai trò" />
        </div>
      </Form>
    </div>
  );
};
