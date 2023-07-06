import { Link } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faPlusCircle, faSort } from '@fortawesome/free-solid-svg-icons';
import { useEffect } from 'react';
import { RootState, useAppDispatch, useAppSelector } from '../../reducers';
import { fetchAll } from '../../reducers/roleSlice';

export const RoleList = () => {
  const dispatch = useAppDispatch();
  const { roles } = useAppSelector((state: RootState) => state.role);

  useEffect(() => {
    dispatch(fetchAll());
  }, [dispatch]);
  // if (isLoading) {
  //   return <div>Loading...</div>;
  // }

  // if (error) {
  //   return <div>Error: {error}</div>;
  // }
  return (
    <div>
      <p className="py-10 text-center font-bold text-slate-500">
        DANH SÁCH VAI TRÒ
      </p>
      <div className="px-36">
        <Link className="text-green-600 text-2xl" to="create">
          <FontAwesomeIcon icon={faPlusCircle} />
        </Link>
      </div>
      <div className="relative overflow-x-auto py-8 lg:px-32 px-6">
        <table className="w-full text-sm text-left text-gray-500 dark:text-gray-400">
          <thead className="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
            <tr>
              <th scope="col" className="px-6 py-3 w-1/3">
                <div className="flex items-center">
                  Mã vai trò
                  <FontAwesomeIcon
                    className="px-2 hover:cursor-pointer active:opacity-50"
                    icon={faSort}
                  />
                </div>
              </th>

              <th scope="col" className="px-6 py-3 w-1/3">
                <div className="flex items-center">
                  Tên vai trò
                  <FontAwesomeIcon
                    className="px-2 hover:cursor-pointer active:opacity-50"
                    icon={faSort}
                  />
                </div>
              </th>
              <th scope="col" className="px-6 py-3 w-1/3 text-center"></th>
            </tr>
          </thead>
          <tbody>
            {roles.map((role, index) => {
              return (
                <tr key={index} className="bg-white dark:bg-gray-800">
                  <td className="px-6 py-4">{role.role_id}</td>
                  <td className="px-6 py-4">{role.role_name}</td>
                  <td className="px-6 py-4 text-center flex justify-around">
                    <Link
                      to={`${role.role_id}`}
                      className="font-medium text-yellow-600 hover:underline"
                    >
                      Cập nhật
                    </Link>
                  </td>
                </tr>
              );
            })}
          </tbody>
        </table>
      </div>
    </div>
  );
};
