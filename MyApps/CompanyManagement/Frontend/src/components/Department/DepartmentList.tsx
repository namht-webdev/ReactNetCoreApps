import { Fragment, useMemo } from 'react';
import { ApiRequest } from '../../reducers';
import { PageTitle } from '../PageTitle';
import { TableData } from '../TableData';

export const DepartmentList = () => {
  const req: ApiRequest = useMemo(() => {
    return {
      title: 'department',
      route: 'department',
    };
  }, []);
  return (
    <Fragment>
      <PageTitle title="DANH SÁCH PHÒNG BAN" />
      <TableData req={req} header={{}} />
    </Fragment>
  );
};
