import React, { useState } from 'react';
import { Form, Values, minLength, required } from '../Context/Form';
import { Field } from '../Context/Field';
import { ApiRequest, DataResponse, useAppDispatch } from '../../reducers';
import { addNew } from '../../reducers/dataSlice';
import { dateShowFm } from '../../utils/convertDateTime';

export const CreateRequirement = () => {
  const dispatch = useAppDispatch();
  const initialValues = {
    requirement_id: 'YC'.concat(Date.now().toString()),
    from_user: 'namht',
    to_user: 'namht',
    date: dateShowFm(new Date().toISOString()),
  };
  const [messageReturn, setMessage] = useState('');
  const handleSubmit = async (requirement: Values) => {
    const req: ApiRequest = {
      route: 'requirement',
      title: 'requirement',
      data: requirement,
    };
    const response = await dispatch(addNew(req));
    const { success, message } = response.payload as DataResponse;
    setMessage(message);
    return { success };
  };
  return (
    <div>
      <p className="py-10 text-center font-bold text-slate-500">
        THÊM MỚI YÊU CẦU
      </p>
      <Form
        submitCaption="Thêm"
        onSubmit={handleSubmit}
        validationRules={{
          requirement_id: [{ validator: required }],
          from_user: [{ validator: required }],
          to_user: [{ validator: required }],
          request_message: [
            { validator: required },
            { validator: minLength, args: 10 },
          ],
        }}
        failureMessage={messageReturn}
        successMessage={messageReturn}
        initialValues={initialValues}
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
