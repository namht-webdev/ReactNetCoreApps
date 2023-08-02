import { Link } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import {
  faPen,
  faPlusCircle,
  faSort,
  faSpinner,
} from '@fortawesome/free-solid-svg-icons';
import { useContext, useEffect, useMemo, useState } from 'react';
import {
  ApiRequest,
  RootState,
  useAppDispatch,
  useAppSelector,
} from '../../reducers';
import { deleteOne, fetchAll } from '../../reducers/dataSlice';
import { Modal } from '../Modal';
import { AuthContext } from '../Context/Authorization';

export const UserList = () => {
  const dispatch = useAppDispatch();
  const { data, isLoading } = useAppSelector((state: RootState) => state.data);
  const { authUser } = useContext(AuthContext);
  const req: ApiRequest = useMemo(() => {
    return {
      title: 'user',
      route: 'user',
    };
  }, []);
  useEffect(() => {
    console.log(authUser?.user_id);
    const doGetUser = async (): Promise<void> => {
      await dispatch(fetchAll(req));
    };
    doGetUser();
  }, [dispatch, req, authUser]);
  const [showModal, setShowModal] = useState(false);
  const [userDelete, setUserDelete] = useState({ id: '', name: '' });
  const handleDeleteUser = async (user_id: string) => {
    const deleteReq: ApiRequest = {
      ...req,
      id: user_id,
    };
    await dispatch(deleteOne(deleteReq));
    setShowModal(false);
  };
  return (
    <div className="h-full">
      <p className="pt-10 text-center font-bold text-slate-500">
        DANH SÁCH NGƯỜI DÙNG
      </p>
      <div className="px-36">
        <Link className="text-green-600 text-2xl" to="create">
          <FontAwesomeIcon icon={faPlusCircle} />
        </Link>
      </div>
      <div className="relative overflow-x-auto py-8 lg:px-32 px-6 h-full xl:h-auto">
        <table className="w-full text-sm text-left text-gray-500 dark:text-gray-400">
          <thead className="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
            <tr>
              <th scope="col" className="px-6 py-3 w-1/8">
                <div className="flex items-center">
                  ID
                  <FontAwesomeIcon
                    className="px-2 hover:cursor-pointer active:opacity-50"
                    icon={faSort}
                  />
                </div>
              </th>

              <th scope="col" className="px-6 py-3 w-1/8">
                <div className="flex items-center">
                  Họ tên
                  <FontAwesomeIcon
                    className="px-2 hover:cursor-pointer active:opacity-50"
                    icon={faSort}
                  />
                </div>
              </th>
              <th scope="col" className="px-6 py-3 w-1/8">
                <div className="flex items-center">
                  Vai trò
                  <FontAwesomeIcon
                    className="px-2 hover:cursor-pointer active:opacity-50"
                    icon={faSort}
                  />
                </div>
              </th>
              <th scope="col" className="px-6 py-3 w-1/8">
                <div className="flex items-center">
                  Bộ phận
                  <FontAwesomeIcon
                    className="px-2 hover:cursor-pointer active:opacity-50"
                    icon={faSort}
                  />
                </div>
              </th>
              <th scope="col" className="px-6 py-3 w-1/8">
                <div className="flex items-center">
                  Cấp
                  <FontAwesomeIcon
                    className="px-2 hover:cursor-pointer active:opacity-50"
                    icon={faSort}
                  />
                </div>
              </th>
              <th scope="col" className="px-6 py-3 w-1/8">
                <div className="flex items-center">
                  Email
                  <FontAwesomeIcon
                    className="px-2 hover:cursor-pointer active:opacity-50"
                    icon={faSort}
                  />
                </div>
              </th>
              <th scope="col" className="px-6 py-3 w-1/8">
                <div className="flex items-center">
                  Số điện thoại
                  <FontAwesomeIcon
                    className="px-2 hover:cursor-pointer active:opacity-50"
                    icon={faSort}
                  />
                </div>
              </th>
              <th scope="col" className="px-6 py-3 w-1/8 text-center">
                <FontAwesomeIcon icon={faPen} />
              </th>
            </tr>
          </thead>
          <tbody>
            {isLoading && (
              <tr>
                <td className="px-6 py-4">
                  <FontAwesomeIcon icon={faSpinner} spin />
                </td>
              </tr>
            )}
            {data.map((user, index) => {
              return (
                <tr key={index} className="bg-white dark:bg-gray-800">
                  <td className="px-6 py-4">{user.user_id}</td>
                  <td className="px-6 py-4">{user.full_name}</td>
                  <td className="px-6 py-4">{user.role_id}</td>
                  <td className="px-6 py-4">{user.department_id}</td>
                  <td className="px-6 py-4">{user.level_id}</td>
                  <td className="px-6 py-4">{user.email}</td>
                  <td className="px-6 py-4">{user.phone_number}</td>
                  <td className="px-6 py-4 text-center flex justify-around">
                    <Link
                      to={`${user.user_id}`}
                      className="font-medium text-yellow-600 hover:underline"
                    >
                      Cập nhật
                    </Link>
                    <span
                      className="font-bold hover:underline cursor-pointer text-red-700"
                      onClick={() => {
                        setShowModal(true);
                        setUserDelete({
                          id: user.user_id,
                          name: user.full_name,
                        });
                      }}
                    >
                      Xóa
                    </span>
                    {showModal && (
                      <Modal
                        title="người dùng"
                        name={`${userDelete.name}`}
                        onConfirm={() => {
                          handleDeleteUser(userDelete.id);
                        }}
                        onCancel={() => {
                          setShowModal(false);
                        }}
                      />
                    )}
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
