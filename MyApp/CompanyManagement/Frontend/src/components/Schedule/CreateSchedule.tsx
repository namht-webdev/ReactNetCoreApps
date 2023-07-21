import React, { useState } from 'react';
import { Form, Values, required } from '../Context/Form';
import { Field } from '../Context/Field';
import { ApiRequest, DataResponse, useAppDispatch } from '../../reducers';
import { addNew } from '../../reducers/dataSlice';
import { timeLine } from '../../utils/utilsData';

export const CreateSchedule = () => {
  const dispatch = useAppDispatch();
  const [messageReturn, setMessage] = useState('');
  const initialValues = {
    schedule_id: 'LT'.concat(Date.now().toString()),
    user_id: 'namht',
  };
  const handleSubmit = async (schedule: Values) => {
    const req: ApiRequest = {
      route: 'schedule',
      title: 'schedule',
      data: schedule,
    };
    const response = await dispatch(addNew(req));
    const { success, message } = response.payload as DataResponse;
    setMessage(message);
    return { success };
  };
  return (
    <div>
      <p className="py-10 text-center font-bold text-slate-500">
        THÊM MỚI LỊCH TRÌNH
      </p>
      <Form
        submitCaption="Thêm"
        onSubmit={handleSubmit}
        validationRules={{
          schedule_id: [{ validator: required }],
          date: [{ validator: required }],
        }}
        failureMessage={messageReturn}
        successMessage={messageReturn}
        initialValues={initialValues}
      >
        <div className="grid md:grid-cols-2 md:gap-6">
          <Field name="schedule_id" label="Mã lịch trình" isDisabled></Field>
          <Field name="user_id" label="Người dùng" isDisabled></Field>
        </div>
        <div className="grid md:grid-cols-3 md:gap-6">
          <Field name="date" label="Ngày" type="Date"></Field>
          <Field
            name="time_start"
            label="Giờ bắt đầu"
            type="Select"
            optionData={timeLine}
          ></Field>
          <Field
            name="time_end"
            label="Giờ kết thúc"
            type="Select"
            optionData={timeLine}
          ></Field>
        </div>
        <Field name="note" label="Nội dung" type="TextArea"></Field>
      </Form>
    </div>
  );
};
