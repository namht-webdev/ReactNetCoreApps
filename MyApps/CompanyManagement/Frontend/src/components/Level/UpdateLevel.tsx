import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { ApiRequest, DataResponse, useAppDispatch } from '../../reducers';
import { Level } from '../../interfaces';
import { getOne, update } from '../../reducers/dataSlice';
import { Form, Values, required } from '../Context/Form';
import { Field } from '../Context/Field';

export const UpdateLevel = () => {
  const { level_id } = useParams();
  const dispatch = useAppDispatch();
  // const { isLoading } = useAppSelector((state: RootState) => state.Level);
  const [level, setLevel] = useState<Level | null>(null);

  const navigate = useNavigate();
  useEffect(() => {
    const doGetLevel = async () => {
      const req: ApiRequest = {
        title: 'level',
        route: 'level',
        id: level_id,
      };
      const response = await dispatch(getOne(req!));
      const { success, data } = response.payload as DataResponse;
      success === true ? setLevel(data) : navigate(`/notfound`);
    };
    doGetLevel();
  }, [dispatch, level_id, navigate]);

  const [messageReturn, setMessage] = useState('');
  const handleSubmit = async (level: Values) => {
    const req: ApiRequest = {
      title: 'level',
      route: 'level',
      id: level_id,
      data: level,
    };
    const response = await dispatch(update(req));
    const { success, message } = response.payload as DataResponse;
    setMessage(message);
    alert(message);
    return { success, redirectUrl: '/level' };
  };
  return (
    <div>
      <div className="pt-24">
        <Form
          submitCaption="Cập nhật"
          onSubmit={handleSubmit}
          validationRules={{
            level_id: [{ validator: required }],
            level_name: [{ validator: required }],
          }}
          initialValues={level ? level : {}}
          failureMessage={messageReturn}
          successMessage={messageReturn}
        >
          <div className="grid md:grid-cols-2 md:gap-6">
            <Field name="level_id" label="Mã cấp độ" isDisabled={true} />
            <Field name="level_name" label="Tên cấp độ" />
          </div>
        </Form>
      </div>
    </div>
  );
};
