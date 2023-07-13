import React, { useEffect, useMemo, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { ApiRequest, DataResponse, useAppDispatch } from '../../reducers';
import { Requirement } from '../../interfaces';
import { getOne, update } from '../../reducers/dataSlice';
import { Form, Values, required } from '../Context/Form';
import { Field } from '../Context/Field';

export const UpdateRequirement = () => {
  const { requirement_id } = useParams();
  const dispatch = useAppDispatch();
  const [requirement, setRequirement] = useState<Requirement | null>(null);

  const navigate = useNavigate();
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
    doGetRequirement();
  }, [dispatch, navigate, req]);

  const [messageReturn, setMessage] = useState('');
  const handleSubmit = async (Requirement: Values) => {
    const updateReq: ApiRequest = {
      ...req,
      data: Requirement,
    };
    const response = await dispatch(update(updateReq));
    const { success, message } = response.payload as DataResponse;
    setMessage(message);
    alert(message);
    return { success, redirectUrl: '/requirement' };
  };
  return (
    <div>
      <div className="pt-24">
        <Form
          submitCaption="Cập nhật"
          onSubmit={handleSubmit}
          validationRules={{
            requirement_id: [{ validator: required }],
          }}
          initialValue={requirement ? requirement : {}}
          failureMessage={messageReturn}
          successMessage={messageReturn}
        >
          <div className="grid md:grid-cols-3 md:gap-6">
            <Field name="requirement_id" label="Mã yêu cầu" isDisabled></Field>
          </div>
        </Form>
      </div>
    </div>
  );
};
