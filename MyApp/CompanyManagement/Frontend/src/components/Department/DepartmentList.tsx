import { Link } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import {
  faPen,
  faPlusCircle,
  faSort,
  faSpinner,
} from '@fortawesome/free-solid-svg-icons';
import { useEffect, useMemo, useState } from 'react';
import {
  ApiRequest,
  RootState,
  useAppDispatch,
  useAppSelector,
} from '../../reducers';
import { deleteOne, fetchAll } from '../../reducers/dataSlice';
import { Modal } from '../Modal';
import { Department } from '../../interfaces';

export const DepartmentList = () => {
  const dispatch = useAppDispatch();
  const { data, isLoading } = useAppSelector((state: RootState) => state.data);
  const req: ApiRequest = useMemo(() => {
    return {
      title: 'department',
      route: 'department',
    };
  }, []);
  useEffect(() => {
    const doGetDepartment = async (): Promise<void> => {
      await dispatch(fetchAll(req));
    };
    doGetDepartment();
  }, [dispatch, req]);
  const [showModal, setShowModal] = useState(false);
  const [departmentDelete, setDepartmentDelete] = useState<Department>();
  const handleDeleteDepartment = async (department_id: string) => {
    const deleteReq: ApiRequest = {
      ...req,
      id: department_id,
    };
    await dispatch(deleteOne(deleteReq));
    setShowModal(false);
  };
  return (
    <div>
      <p className="py-10 text-center font-bold text-slate-500">
        DANH SÁCH PHÒNG BAN
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
              <th scope="col" className="px-6 py-3 w-1/4">
                <div className="flex items-center">
                  Mã phòng ban
                  <FontAwesomeIcon
                    className="px-2 hover:cursor-pointer active:opacity-50"
                    icon={faSort}
                  />
                </div>
              </th>

              <th scope="col" className="px-6 py-3 w-1/4">
                <div className="flex items-center">
                  Tên phòng ban
                  <FontAwesomeIcon
                    className="px-2 hover:cursor-pointer active:opacity-50"
                    icon={faSort}
                  />
                </div>
              </th>
              <th scope="col" className="px-6 py-3 w-1/4">
                <div className="flex items-center">
                  Tầng
                  <FontAwesomeIcon
                    className="px-2 hover:cursor-pointer active:opacity-50"
                    icon={faSort}
                  />
                </div>
              </th>
              <th scope="col" className="px-6 py-3 w-1/4 text-center">
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
            {data.map((department, index) => {
              return (
                <tr key={index} className="bg-white dark:bg-gray-800">
                  <td className="px-6 py-4">{department.department_id}</td>
                  <td className="px-6 py-4">{department.department_name}</td>
                  <td className="px-6 py-4">{department.floor}</td>
                  <td className="px-6 py-4 text-center grid md:grid-cols-2 md:gap-1">
                    <Link
                      to={`${department.department_id}`}
                      className="font-medium text-yellow-600 hover:underline"
                    >
                      Cập nhật
                    </Link>
                    <span
                      className="font-bold hover:underline cursor-pointer text-red-700"
                      onClick={() => {
                        setShowModal(true);
                        setDepartmentDelete({
                          department_id: department.department_id,
                          department_name: department.department_name,
                          floor: department.floor,
                        });
                      }}
                    >
                      Xóa
                    </span>
                    {showModal && (
                      <Modal
                        title="phòng ban"
                        name={`${departmentDelete?.department_name}`}
                        onConfirm={() => {
                          handleDeleteDepartment(
                            departmentDelete!.department_id,
                          );
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
