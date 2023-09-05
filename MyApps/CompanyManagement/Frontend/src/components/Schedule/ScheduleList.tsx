import { Fragment, useMemo } from 'react';
import { ApiRequest } from '../../reducers';
import { PageTitle } from '../PageTitle';
import { TableData } from '../TableData';

export const ScheduleList = () => {
  const req: ApiRequest = useMemo(() => {
    return {
      title: 'schedule',
      route: 'schedule',
    };
  }, []);
  const header = useMemo(() => {
    return {
      schedule_id: 'Mã lịch trình',
      date: 'Ngày',
      note: 'Nội dung',
      time_start: 'Giờ bắt đầu',
      time_end: 'Giờ kết thúc',
    };
  }, []);
  return (
    <Fragment>
      <PageTitle title="LỊCH LÀM VIỆC" />
      <TableData req={req} header={header} />
    </Fragment>
  );
};
