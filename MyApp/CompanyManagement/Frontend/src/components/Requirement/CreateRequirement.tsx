import React, { useState } from 'react';
import { Form, Values, minLength, required } from '../Context/Form';
import { Field } from '../Context/Field';
import { ApiRequest, DataResponse, useAppDispatch } from '../../reducers';
import { addNew } from '../../reducers/dataSlice';

export const CreateRequirement = () => {
  const dispatch = useAppDispatch();
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
          to_user: [{ validator: required }],
          message: [
            { validator: required },
            { validator: minLength, args: 10 },
          ],
        }}
        failureMessage={messageReturn}
        successMessage={messageReturn}
      >
        <div className="grid md:grid-cols-2 md:gap-6">
          <Field
            name="requirement_id"
            label="Mã yêu cầu"
            isDisabled
            defaultValue={'YC'.concat(Date.now().toString())}
          ></Field>
          <Field name="date" label="Ngày" type="DateTime" isDisabled></Field>
        </div>
        <div className="grid md:grid-cols-2 md:gap-6">
          <Field
            name="from_user"
            label="Từ người dùng"
            isDisabled
            defaultValue={'namht'}
          ></Field>
          <Field name="to_user" label="Chọn người dùng" type="Select"></Field>
        </div>
        <Field name="message" label="Nội dung" type="TextArea"></Field>
      </Form>
    </div>
  );
};
