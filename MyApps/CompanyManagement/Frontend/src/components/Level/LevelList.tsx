import { ApiRequest } from '../../reducers';
import { PageTitle } from '../PageTitle';
import { AddButton } from '../AddButton';
import { TableData } from '../TableData';
import { Fragment, useMemo } from 'react';

const LevelList = () => {
  const req: ApiRequest = useMemo(() => {
    return {
      route: 'level',
      title: 'level',
    };
  }, []);
  return (
    <Fragment>
      <PageTitle title="DANH SÁCH CHỨC VỤ" />
      <AddButton />
      <TableData req={req} header={{}} />
    </Fragment>
  );
};

export default LevelList;
