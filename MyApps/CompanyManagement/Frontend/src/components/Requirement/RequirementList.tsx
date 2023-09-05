import { Fragment, useMemo } from 'react';
import { ApiRequest } from '../../reducers';
import { PageTitle } from '../PageTitle';
import { TableData } from '../TableData';
import { useAuth } from '../Context/Authorization';

export const RequirementList = () => {
  const { authUser } = useAuth();
  const req: ApiRequest = useMemo(() => {
    return {
      title: 'requirement',
      route: 'requirement',
    };
  }, []);
  const header = useMemo(() => {
    let rHeader = {
      requirement_id: 'Mã yêu cầu',
      from_user: 'Yêu cầu từ',
      date: 'Ngày',
      request_message: 'Nội dung yêu cầu',
    };
    return authUser?.role_id === 'admin'
      ? {
          ...rHeader,
          to_user: 'Yêu cầu đến',
        }
      : rHeader;
  }, [authUser]);
  return (
    <Fragment>
      <PageTitle title="DANH SÁCH YÊU CẦU" />
      <TableData req={req} header={header} />
    </Fragment>
  );
};
