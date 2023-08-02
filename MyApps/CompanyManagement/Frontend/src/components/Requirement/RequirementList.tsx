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
import { dateShowFm } from '../../utils/convertDateTime';

export const RequirementList = () => {
  const dispatch = useAppDispatch();
  const { data, isLoading } = useAppSelector((state: RootState) => state.data);
  const req: ApiRequest = useMemo(() => {
    return {
      title: 'requirement',
      route: 'requirement',
    };
  }, []);
  useEffect(() => {
    const doGetRequirement = async (): Promise<void> => {
      await dispatch(fetchAll(req));
    };
    doGetRequirement();
  }, [dispatch, req]);
  const [showModal, setShowModal] = useState(false);
  const [requirementDelete, setRequirementDelete] = useState<string>('');
  const handleDeleteRequirement = async (requirement_id: string) => {
    const deleteReq: ApiRequest = {
      ...req,
      id: requirement_id,
    };
    await dispatch(deleteOne(deleteReq));
    setShowModal(false);
  };
  return (
    <div>
      <p className="py-10 text-center font-bold text-slate-500">
        DANH SÁCH YÊU CẦU
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
              <th scope="col" className="px-6 py-3 w-1/6">
                <div className="flex items-center">
                  Mã yêu cầu
                  <FontAwesomeIcon
                    className="px-2 hover:cursor-pointer active:opacity-50"
                    icon={faSort}
                  />
                </div>
              </th>

              <th scope="col" className="px-6 py-3 w-1/6">
                <div className="flex items-center">
                  Từ người dùng
                  <FontAwesomeIcon
                    className="px-2 hover:cursor-pointer active:opacity-50"
                    icon={faSort}
                  />
                </div>
              </th>
              <th scope="col" className="px-6 py-3 w-1/6">
                <div className="flex items-center">
                  Đến người dùng
                  <FontAwesomeIcon
                    className="px-2 hover:cursor-pointer active:opacity-50"
                    icon={faSort}
                  />
                </div>
              </th>
              <th scope="col" className="px-6 py-3 w-1/6">
                <div className="flex items-center">
                  Ngày
                  <FontAwesomeIcon
                    className="px-2 hover:cursor-pointer active:opacity-50"
                    icon={faSort}
                  />
                </div>
              </th>

              <th scope="col" className="px-6 py-3 w-1/6">
                <div className="flex items-center">
                  Nội dung
                  <FontAwesomeIcon
                    className="px-2 hover:cursor-pointer active:opacity-50"
                    icon={faSort}
                  />
                </div>
              </th>
              <th scope="col" className="px-6 py-3 w-1/6 text-center">
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
            {data.map((requirement, index) => {
              return (
                <tr key={index} className="bg-white dark:bg-gray-800">
                  <td className="px-6 py-4">{requirement.requirement_id}</td>
                  <td className="px-6 py-4">{requirement.from_user}</td>
                  <td className="px-6 py-4">{requirement.to_user}</td>
                  <td className="px-6 py-4">
                    {dateShowFm(requirement.date?.toString())}
                  </td>
                  <td className="px-6 py-4">{requirement.message}</td>
                  <td className="px-6 py-4 text-center grid md:grid-cols-2 md:gap-1">
                    <Link
                      to={`${requirement.requirement_id}`}
                      className="font-medium text-yellow-600 hover:underline"
                    >
                      Cập nhật
                    </Link>
                    <span
                      className="font-bold hover:underline cursor-pointer text-red-700"
                      onClick={() => {
                        setShowModal(true);
                        setRequirementDelete(requirement.requirement_id);
                      }}
                    >
                      Xóa
                    </span>
                    {showModal && (
                      <Modal
                        title="Yêu cầu"
                        name={`${requirementDelete}`}
                        onConfirm={() => {
                          handleDeleteRequirement(requirementDelete);
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
