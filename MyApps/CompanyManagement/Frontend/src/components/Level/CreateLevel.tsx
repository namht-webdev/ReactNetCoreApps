import { useState } from 'react';
import { Form, Values, required } from '../Context/Form';
import { Field } from '../Context/Field';
import { ApiRequest, DataResponse, useAppDispatch } from '../../reducers';
import { addNew } from '../../reducers/dataSlice';

export const CreateLevel = () => {
  const dispatch = useAppDispatch();
  const [messageReturn, setMessage] = useState('');
  const handleSubmit = async (level: Values) => {
    const req: ApiRequest = {
      route: 'level',
      title: 'level',
      data: level,
    };
    const response = await dispatch(addNew(req));
    const { success, message } = response.payload as DataResponse;
    setMessage(message);
    return { success };
  };
  return (
    <div>
      <p className="py-10 text-center font-bold text-slate-500">
        THÊM MỚI CẤP ĐỘ
      </p>
      <Form
        submitCaption="Thêm"
        onSubmit={handleSubmit}
        validationRules={{
          level_id: [{ validator: required }],
          level_name: [{ validator: required }],
        }}
        failureMessage={messageReturn}
        successMessage={messageReturn}
      >
        <div className="grid md:grid-cols-2 md:gap-6">
          <Field name="level_id" label="Mã cấp độ"></Field>
          <Field name="level_name" label="Tên cấp độ"></Field>
        </div>
      </Form>
    </div>
  );
};
