import React, { useState } from 'react';
import { Form, Values, mustBeNumber, required } from '../Context/Form';
import { Field } from '../Context/Field';
import { ApiRequest, DataResponse, useAppDispatch } from '../../reducers';
import { addNew } from '../../reducers/dataSlice';

export const CreateSchedule = () => {
  const dispatch = useAppDispatch();
  const [messageReturn, setMessage] = useState('');
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
        }}
        failureMessage={messageReturn}
        successMessage={messageReturn}
      >
        <div className="grid md:grid-cols-3 md:gap-6">
          <Field
            name="schedule_id"
            label="Mã lịch trình"
            defaultValue={'LT'.concat(Date.now().toString())}
            isDisabled
          ></Field>
        </div>
      </Form>
    </div>
  );
};
