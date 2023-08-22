import React, { useEffect, useMemo, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { ApiRequest, DataResponse, useAppDispatch } from '../../reducers';
import { Department } from '../../interfaces';
import { addNew, getOne, update } from '../../reducers/dataSlice';
import { Form, Values, mustBeNumber, required } from '../Context/Form';
import { Field } from '../Context/Field';
import { PageTitle } from '../PageTitle';

export const DepartmentAction = () => {
  const { department_id } = useParams();
  const dispatch = useAppDispatch();
  const [department, setDepartment] = useState<Department | null>(null);
  const [messageReturn, setMessage] = useState('');
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
    if (department_id) doGetDepartment();
  }, [dispatch, department_id, navigate, req]);

  const handleSubmit = async (department: Values) => {
    const actReq: ApiRequest = {
      ...req,
      data: department,
    };
    const response = department_id
      ? await dispatch(update(actReq))
      : await dispatch(addNew(actReq));
    const { success, message } = response.payload as DataResponse;
    setMessage(message);
    alert(message);
    return { success, redirectUrl: '/department' };
  };
  const title = department_id ? 'CẬP NHẬT' : 'THÊM';

  return (
    <div>
      <PageTitle title={`${title} PHÒNG BAN`} />
      <Form
        submitCaption={title}
        onSubmit={handleSubmit}
        validationRules={{
          department_id: [{ validator: required }],
          department_name: [{ validator: required }],
          floor: [{ validator: required }, { validator: mustBeNumber }],
        }}
        initialValues={department ? department : {}}
        failureMessage={messageReturn}
      >
        <div className="grid md:grid-cols-3 md:gap-6">
          <Field
            name="department_id"
            label="Mã phòng ban"
            isDisabled={department_id ? true : false}
          ></Field>
          <Field name="department_name" label="Tên phòng ban"></Field>
          <Field name="floor" label="Tầng"></Field>
        </div>
      </Form>
    </div>
  );
};
