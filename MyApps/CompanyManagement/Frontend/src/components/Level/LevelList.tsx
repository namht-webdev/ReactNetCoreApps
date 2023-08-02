import {
  faPen,
  faPlusCircle,
  faSort,
  faSpinner,
} from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { useState, useEffect, useMemo } from 'react';
import { Link } from 'react-router-dom';
import {
  ApiRequest,
  RootState,
  useAppDispatch,
  useAppSelector,
} from '../../reducers';
import { Modal } from '../Modal';
import { deleteOne, fetchAll } from '../../reducers/dataSlice';
import { Level } from '../../interfaces';

const LevelList = () => {
  const dispatch = useAppDispatch();
  const { data, isLoading } = useAppSelector((state: RootState) => state.data);
  const req: ApiRequest = useMemo(() => {
    return {
      route: 'level',
      title: 'level',
    };
  }, []);
  useEffect(() => {
    dispatch(fetchAll(req));
  }, [dispatch, req]);

  const [showModal, setShowModal] = useState(false);
  const [levelDelete, setLevelDelete] = useState<Level>();
  const handleDeletelevel = async (level_id: string) => {
    const req: ApiRequest = {
      title: 'level',
      route: 'level',
      id: level_id,
    };
    await dispatch(deleteOne(req));
    setShowModal(false);
  };
  return (
    <div>
      <p className="py-10 text-center font-bold text-slate-500">
        DANH SÁCH CẤP ĐỘ
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
                  Mã cấp độ
                  <FontAwesomeIcon
                    className="px-2 hover:cursor-pointer active:opacity-50"
                    icon={faSort}
                  />
                </div>
              </th>

              <th scope="col" className="px-6 py-3 w-1/3">
                <div className="flex items-center">
                  Tên cấp độ
                  <FontAwesomeIcon
                    className="px-2 hover:cursor-pointer active:opacity-50"
                    icon={faSort}
                  />
                </div>
              </th>
              <th scope="col" className="px-6 py-3 w-1/3 text-center">
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
            {data?.map((level, index) => {
              return (
                <tr key={index} className="bg-white dark:bg-gray-800">
                  <td className="px-6 py-4">{level.level_id}</td>
                  <td className="px-6 py-4">{level.level_name}</td>
                  <td className="px-6 py-4 text-center flex justify-around">
                    <Link
                      to={`${level.level_id}`}
                      className="font-medium text-yellow-600 hover:underline"
                    >
                      Cập nhật
                    </Link>
                    <span
                      className="font-bold hover:underline cursor-pointer text-red-700"
                      onClick={() => {
                        setShowModal(true);
                        setLevelDelete({
                          level_id: level.level_id,
                          level_name: level.level_name,
                        });
                      }}
                    >
                      Xóa
                    </span>
                    {showModal && (
                      <Modal
                        title="cấp độ"
                        name={`${levelDelete?.level_name}`}
                        onConfirm={() => {
                          handleDeletelevel(levelDelete!.level_id);
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

export default LevelList;
