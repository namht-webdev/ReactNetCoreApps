import { TableData } from '../TableData';
import { ApiRequest } from '../../reducers';
import { Fragment, useMemo } from 'react';
import { UserVM } from '../../interfaces';
import { PageTitle } from '../PageTitle';

export const UserList = () => {
  const req: ApiRequest = useMemo(() => {
    return {
      title: 'user',
      route: 'user',
    };
  }, []);
  const header: UserVM = useMemo(() => {
    return {
      user_id: 'Mã',
      user_name: 'Tên',
      role_id: 'Vai trò',
      department_id: 'Bộ phận',
      level_id: 'Chức vụ',
    };
  }, []);
  return (
    <Fragment>
      <PageTitle title="DANH SÁCH NGƯỜI DÙNG" />
      <TableData req={req} header={header} />
    </Fragment>
  );
};
