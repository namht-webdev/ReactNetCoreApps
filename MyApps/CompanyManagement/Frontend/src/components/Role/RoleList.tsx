import { Fragment, useMemo } from 'react';
import { ApiRequest } from '../../reducers';
import { TableData } from '../TableData';
import { PageTitle } from '../PageTitle';

export const RoleList = () => {
  const req: ApiRequest = useMemo(() => {
    return {
      title: 'role',
      route: 'role',
    };
  }, []);
  return (
    <Fragment>
      <PageTitle title="DANH SÁCH VAI TRÒ" />
      <TableData
        req={req}
        header={{ role_id: 'Vai trò', role_name: 'Tên vai trò' }}
      />
    </Fragment>
  );
};
