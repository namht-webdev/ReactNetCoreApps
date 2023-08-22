import React, { useEffect, useMemo, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { ApiRequest, DataResponse, useAppDispatch } from '../../reducers';
import { Level } from '../../interfaces';
import { addNew, getOne, update } from '../../reducers/dataSlice';
import { Form, Values, required } from '../Context/Form';
import { Field } from '../Context/Field';
import { PageTitle } from '../PageTitle';

export const LevelAction = () => {
  const { level_id } = useParams();
  const dispatch = useAppDispatch();
  const [level, setLevel] = useState<Level | null>(null);
  const [messageReturn, setMessage] = useState('');
  const navigate = useNavigate();
  const req: ApiRequest = useMemo(() => {
    return {
      title: 'level',
      route: 'level',
      id: level_id,
    };
  }, [level_id]);
  useEffect(() => {
    const doGetLevel = async () => {
      const response = await dispatch(getOne(req!));
      const { success, data } = response.payload as DataResponse;
      success === true ? setLevel(data) : navigate(`/notfound`);
    };
    if (level_id) doGetLevel();
  }, [dispatch, level_id, navigate, req]);

  const handleSubmit = async (level: Values) => {
    const actReq: ApiRequest = {
      ...req,
      data: level,
    };
    const response = level_id
      ? await dispatch(update(actReq))
      : await dispatch(addNew(actReq));
    const { success, message } = response.payload as DataResponse;
    setMessage(message);
    alert(message);
    return { success, redirectUrl: '/level' };
  };
  const title = level_id ? 'CẬP NHẬT' : 'THÊM';
  return (
    <div>
      <PageTitle title={`${title} CẤP ĐỘ`} />
      <Form
        submitCaption={title}
        onSubmit={handleSubmit}
        validationRules={{
          level_id: [{ validator: required }],
          level_name: [{ validator: required }],
        }}
        initialValues={level ? level : {}}
        failureMessage={messageReturn}
      >
        <div className="grid md:grid-cols-2 md:gap-6">
          <Field
            name="level_id"
            label="Mã cấp độ"
            isDisabled={level_id ? true : false}
          />
          <Field name="level_name" label="Tên cấp độ" />
        </div>
      </Form>
    </div>
  );
};
