import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { Modal } from './Modal';
import {
  ApiRequest,
  RootState,
  useAppDispatch,
  useAppSelector,
} from '../reducers';
import { deleteOne, fetchAll } from '../reducers/dataSlice';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faSpinner } from '@fortawesome/free-solid-svg-icons';
import { Values } from './Context/Form';

interface TableDataProps {
  header: Values;
  req: ApiRequest;
}

export const TableData = ({ req, header }: TableDataProps) => {
  const { data, isLoading } = useAppSelector((state: RootState) => state.data);
  const dispatch = useAppDispatch();
  const [showModal, setShowModal] = useState(false);
  const [dataRemmove, setRemoveDelete] = useState({ id: '', name: '' });
  const handleRemoveData = async (id: string) => {
    const deleteReq: ApiRequest = {
      ...req,
      id,
    };
    await dispatch(deleteOne(deleteReq));
    setShowModal(false);
  };
  useEffect(() => {
    const doGetUser = async (): Promise<void> => {
      await dispatch(fetchAll(req));
    };
    doGetUser();
  }, [dispatch, req]);
  if (isLoading) return <div className="">Loading ...</div>;
  return (
    <div className="px-10">
      {data.length > 0 && (
        <div className="outer-wrapper">
          <div className="table-wrapper">
            <table>
              <thead>
                <tr>
                  {Object.keys(data[0]).map((key) => (
                    <th key={key}>{header[key]}</th>
                  ))}
                  <th>Chỉnh sửa</th>
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
                {data.map((d: any) => (
                  <tr key={d[`${req.route}_id`]}>
                    {Object.keys(d).map((k) => (
                      <td key={k}>{d[k as keyof typeof d]}</td>
                    ))}
                    <td className="w-64">
                      <div className="flex justify-between w-full text-center">
                        <Link
                          to={`${d[`${req.route}_id`]}`}
                          className="font-medium text-yellow-600 hover:underline w-full"
                        >
                          Cập nhật
                        </Link>
                        <span
                          className="font-bold hover:underline cursor-pointer text-red-700 w-full"
                          onClick={() => {
                            setShowModal(true);
                            setRemoveDelete &&
                              setRemoveDelete({
                                id: d[`${req.route}_id`],
                                name: d[`${req.route}_name`],
                              });
                          }}
                        >
                          Xóa
                        </span>
                        {showModal && (
                          <Modal
                            title="người dùng"
                            name={`${dataRemmove.name}`}
                            onConfirm={() => {
                              handleRemoveData(dataRemmove.id);
                            }}
                            onCancel={() => {
                              setShowModal(false);
                            }}
                          />
                        )}
                      </div>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        </div>
      )}
    </div>
  );
};
