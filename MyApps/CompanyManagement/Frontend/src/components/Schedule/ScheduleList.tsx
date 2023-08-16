import { Fragment, useMemo } from 'react';
import { ApiRequest } from '../../reducers';
import { PageTitle } from '../PageTitle';
import { AddButton } from '../AddButton';
import { TableData } from '../TableData';

export const ScheduleList = () => {
  const req: ApiRequest = useMemo(() => {
    return {
      title: 'schedule',
      route: 'schedule',
    };
  }, []);

  return (
    <Fragment>
      <PageTitle title="LỊCH LÀM VIỆC" />
      <AddButton />
      <TableData req={req} header={{}} />
    </Fragment>
  );
};
