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

export const ScheduleList = () => {
  const dispatch = useAppDispatch();
  const { data, isLoading } = useAppSelector((state: RootState) => state.data);
  const req: ApiRequest = useMemo(() => {
    return {
      title: 'schedule',
      route: 'schedule',
    };
  }, []);
  useEffect(() => {
    const doGetSchedule = async (): Promise<void> => {
      await dispatch(fetchAll(req));
    };
    doGetSchedule();
  }, [dispatch, req]);
  const [showModal, setShowModal] = useState(false);
  const handleDeleteSchedule = async (schedule_id: string) => {
    const deleteReq: ApiRequest = {
      ...req,
      id: schedule_id,
    };
    await dispatch(deleteOne(deleteReq));
    setShowModal(false);
  };
  return (
    <div>
      <p className="py-10 text-center font-bold text-slate-500">
        LỊCH TRÌNH ĐÃ LÊN
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
                  Mã lịch trình
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
                  Bắt đầu từ
                  <FontAwesomeIcon
                    className="px-2 hover:cursor-pointer active:opacity-50"
                    icon={faSort}
                  />
                </div>
              </th>
              <th scope="col" className="px-6 py-3 w-1/6">
                <div className="flex items-center">
                  Kết thúc lúc
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
            {data.map((schedule, index) => {
              return (
                <tr key={index} className="bg-white dark:bg-gray-800">
                  <td className="px-6 py-4">{schedule.schedule_id}</td>
                  <td className="px-6 py-4">{schedule.date}</td>
                  <td className="px-6 py-4">{schedule.time_start}</td>
                  <td className="px-6 py-4">{schedule.time_end}</td>
                  <td className="px-6 py-4">{schedule.note}</td>
                  <td className="px-6 py-4 text-center grid md:grid-cols-2 md:gap-1">
                    <Link
                      to={`${schedule.schedule_id}`}
                      className="font-medium text-yellow-600 hover:underline"
                    >
                      Cập nhật
                    </Link>
                    <span
                      className="font-bold hover:underline cursor-pointer text-red-700"
                      onClick={() => {
                        setShowModal(true);
                      }}
                    >
                      Xóa
                    </span>
                    {showModal && (
                      <Modal
                        title="phòng ban"
                        name={`${schedule?.schedule_id}`}
                        onConfirm={() => {
                          handleDeleteSchedule(schedule.schedule_id);
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
