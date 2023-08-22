import React, { useEffect, useMemo, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { ApiRequest, DataResponse, useAppDispatch } from '../../reducers';
import { Requirement } from '../../interfaces';
import { addNew, getOne, update } from '../../reducers/dataSlice';
import { Form, Values, required } from '../Context/Form';
import { Field } from '../Context/Field';
import { PageTitle } from '../PageTitle';
import { dateShowFm } from '../../utils/convertDateTime';
import { useAuth } from '../Context/Authorization';

export const RequirementAction = () => {
  const { requirement_id } = useParams();
  const dispatch = useAppDispatch();
  const [requirement, setRequirement] = useState<Requirement | null>(null);
  const { authUser } = useAuth();
  const navigate = useNavigate();
  const initialValues = {
    requirement_id: 'YC'.concat(Date.now().toString()),
    from_user: authUser?.user_id,
    to_user: 'namht',
    date: dateShowFm(new Date().toISOString()),
  };
  const req: ApiRequest = useMemo(() => {
    return {
      title: 'requirement',
      route: 'requirement',
      id: requirement_id,
    };
  }, [requirement_id]);
  useEffect(() => {
    const doGetRequirement = async () => {
      const response = await dispatch(getOne(req!));
      const { success, data } = response.payload as DataResponse;
      success === true ? setRequirement(data) : navigate(`/notfound`);
    };
    if (requirement_id) doGetRequirement();
  }, [dispatch, navigate, req, requirement_id]);

  const [messageReturn, setMessage] = useState('');
  const handleSubmit = async (Requirement: Values) => {
    const actReq: ApiRequest = {
      ...req,
      data: Requirement,
    };
    const response = requirement_id
      ? await dispatch(update(actReq))
      : await dispatch(addNew(actReq));
    const { success, message } = response.payload as DataResponse;
    setMessage(message);
    alert(message);
    return { success, redirectUrl: '/requirement' };
  };
  const title = requirement_id ? 'CẬP NHẬT' : 'THÊM';

  return (
    <div>
      <PageTitle title={`${title} PHÒNG BAN`} />
      <Form
        submitCaption={title}
        onSubmit={handleSubmit}
        validationRules={{
          requirement_id: [{ validator: required }],
        }}
        initialValues={requirement ? requirement : initialValues}
        failureMessage={messageReturn}
      >
        <div className="grid md:grid-cols-2 md:gap-6">
          <Field name="requirement_id" label="Mã yêu cầu" isDisabled></Field>
          <Field name="date" label="Ngày" isDisabled></Field>
        </div>
        <div className="grid md:grid-cols-2 md:gap-6">
          <Field name="from_user" label="Từ người dùng" isDisabled></Field>
          <Field name="to_user" label="Đến người dùng"></Field>
        </div>
        <Field name="request_message" label="Nội dung" type="TextArea"></Field>
      </Form>
    </div>
  );
};
