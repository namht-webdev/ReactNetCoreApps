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
import { v4 as uuidv4 } from 'uuid';
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
  if (isLoading)
    return (
      <div className="w-full flex justify-center items-center">
        Loading &nbsp; &nbsp; &nbsp;
        <FontAwesomeIcon icon={faSpinner} spin />
      </div>
    );
  return (
    <div className="px-12 sm:px-10 pt-6">
      {data.length > 0 && (
        <div className="outer-wrapper hidTable">
          <div className="table-wrapper">
            <table>
              <thead>
                <tr>
                  {Object.keys(header).map((key) => (
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
                  <tr key={uuidv4()}>
                    {Object.keys(header).map((k) => (
                      <td key={uuidv4()}>{d[k as keyof typeof d]}</td>
                    ))}
                    <td className="w-64">
                      <div className="flex justify-between w-full text-center">
                        <Link
                          to={`update/${d[`${req.route}_id`]}`}
                          className="font-medium text-cyan-400 hover:underline w-full"
                        >
                          Cập nhật
                        </Link>
                        <span
                          className="font-bold hover:underline cursor-pointer text-orange-400 w-full"
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
