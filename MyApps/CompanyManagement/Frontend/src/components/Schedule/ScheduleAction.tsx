import React, { useEffect, useMemo, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { ApiRequest, DataResponse, useAppDispatch } from '../../reducers';
import { Schedule } from '../../interfaces';
import { addNew, getOne, update } from '../../reducers/dataSlice';
import { Form, Values, required } from '../Context/Form';
import { Field } from '../Context/Field';
import { timeLine } from '../../utils/utilsData';
import { PageTitle } from '../PageTitle';

export const ScheduleAction = () => {
  const { schedule_id } = useParams();
  const dispatch = useAppDispatch();
  const [schedule, setSchedule] = useState<Schedule | null>(null);
  const navigate = useNavigate();
  const initialValues = {
    schedule_id: 'LT'.concat(Date.now().toString()),
    user_id: 'namht',
  };
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
    if (schedule_id) doGetSchedule();
  }, [dispatch, navigate, req, schedule_id]);

  const [messageReturn, setMessage] = useState('');
  const handleSubmit = async (schedule: Values) => {
    const actReq: ApiRequest = {
      ...req,
      data: schedule,
    };
    const response = schedule_id
      ? await dispatch(update(actReq))
      : await dispatch(addNew(actReq));
    const { success, message } = response.payload as DataResponse;
    setMessage(message);
    alert(message);
    return { success, redirectUrl: '/schedule' };
  };
  const title = schedule_id ? 'CẬP NHẬT' : 'THÊM';

  return (
    <div>
      <PageTitle title={`${title} LỊCH LÀM VIỆC`} />
      <Form
        submitCaption={title}
        onSubmit={handleSubmit}
        validationRules={{
          schedule_id: [{ validator: required }],
          date: [{ validator: required }],
        }}
        initialValues={schedule ? schedule : initialValues}
        failureMessage={messageReturn}
        successMessage={messageReturn}
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
      </Form>
    </div>
  );
};
