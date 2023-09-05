import { ApiRequest } from '../../reducers';
import { PageTitle } from '../PageTitle';
import { TableData } from '../TableData';
import { Fragment, useMemo } from 'react';

const LevelList = () => {
  const req: ApiRequest = useMemo(() => {
    return {
      route: 'level',
      title: 'level',
    };
  }, []);
  const header = useMemo(() => {
    return {
      level_id: 'Chức vụ',
      level_name: 'Tên chức vụ',
    };
  }, []);
  return (
    <Fragment>
      <PageTitle title="DANH SÁCH CHỨC VỤ" />
      <TableData req={req} header={header} />
    </Fragment>
  );
};

export default LevelList;
