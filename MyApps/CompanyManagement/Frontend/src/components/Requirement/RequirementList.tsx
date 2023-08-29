import { Fragment, useMemo } from 'react';
import { ApiRequest } from '../../reducers';
import { PageTitle } from '../PageTitle';
import { TableData } from '../TableData';

export const RequirementList = () => {
  const req: ApiRequest = useMemo(() => {
    return {
      title: 'requirement',
      route: 'requirement',
    };
  }, []);
  return (
    <Fragment>
      <PageTitle title="DANH SÁCH YÊU CẦU" />
      <TableData req={req} header={{}} />
    </Fragment>
  );
};
