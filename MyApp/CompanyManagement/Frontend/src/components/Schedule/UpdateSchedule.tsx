import React, { useEffect, useMemo, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { ApiRequest, DataResponse, useAppDispatch } from '../../reducers';
import { Schedule } from '../../interfaces';
import { getOne, update } from '../../reducers/dataSlice';
import { Form, Values, mustBeNumber, required } from '../Context/Form';
import { Field } from '../Context/Field';

export const UpdateSchedule = () => {
  const { schedule_id } = useParams();
  const dispatch = useAppDispatch();
  const [schedule, setSchedule] = useState<Schedule | null>(null);

  const navigate = useNavigate();
  const req: ApiRequest = useMemo(() => {
    return {
      title: 'schedule',
      route: 'schedule',
      id: schedule_id,
    };
  }, [schedule_id]);
  useEffect(() => {
    const doGetSchedule = async () => {
      const response = await dispatch(getOne(req!));
      const { success, data } = response.payload as DataResponse;
      success === true ? setSchedule(data) : navigate(`/notfound`);
    };
    doGetSchedule();
  }, [dispatch, navigate, req]);

  const [messageReturn, setMessage] = useState('');
  const handleSubmit = async (schedule: Values) => {
    const updateReq: ApiRequest = {
      ...req,
      data: schedule,
    };
    const response = await dispatch(update(updateReq));
    const { success, message } = response.payload as DataResponse;
    setMessage(message);
    alert(message);
    return { success, redirectUrl: '/schedule' };
  };
  return (
    <div>
      <div className="pt-24">
        <Form
          submitCaption="Cập nhật"
          onSubmit={handleSubmit}
          validationRules={{
            Schedule_id: [{ validator: required }],
            Schedule_name: [{ validator: required }],
            floor: [{ validator: required }, { validator: mustBeNumber }],
          }}
          initialValue={schedule ? schedule : {}}
          failureMessage={messageReturn}
          successMessage={messageReturn}
        >
          <div className="grid md:grid-cols-3 md:gap-6">
            <Field name="schedule_id" label="Mã lịch trình" isDisabled></Field>
          </div>
        </Form>
      </div>
    </div>
  );
};
