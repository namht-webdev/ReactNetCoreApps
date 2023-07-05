import { Form, Values, required } from '../Context/Form';
import { Field } from '../Context/Field';
import { Link } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faSort } from '@fortawesome/free-solid-svg-icons';
import { useEffect } from 'react';
import { RootState, useAppDispatch, useAppSelector } from '../../reducers';
import { addNew, fetchAll } from '../../reducers/roleSlice';
import { Role } from '../../interfaces/Role';

export const RoleList = () => {
  const dispatch = useAppDispatch();
  const { roles, isLoading, error } = useAppSelector(
    (state: RootState) => state.role,
  );

  useEffect(() => {
    dispatch(fetchAll());
  }, [dispatch]);

  const handleSubmit = (role: Values) => {
    dispatch(addNew(role as Role));
  };
  return (
    <div>
      <p className="py-10 text-center font-bold text-slate-500">
        DANH SÁCH VAI TRÒ
      </p>
      <Form
        submitCaption="Thêm"
        onSubmit={handleSubmit}
        validationRules={{
          role_name: { validator: required },
          role_id: { validator: required },
        }}
      >
        <div className="grid md:grid-cols-2 md:gap-6">
          <Field name="role_id" label="Mã vai trò"></Field>
          <Field name="role_name" label="Tên vai trò"></Field>
        </div>
      </Form>

      <div className="relative overflow-x-auto py-16 lg:px-32 px-6">
        <table className="w-full text-sm text-left text-gray-500 dark:text-gray-400">
          <thead className="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
            <tr>
              <th scope="col" className="px-6 py-3 w-1/3">
                <div className="flex items-center">
                  Mã
                  <FontAwesomeIcon
                    className="px-2 hover:cursor-pointer active:opacity-50"
                    icon={faSort}
                  />
                </div>
              </th>

              <th scope="col" className="px-6 py-3 w-1/3">
                <div className="flex items-center">
                  Tên
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
            {isLoading ? (
              <div>Loading ...</div>
            ) : (
              roles.map((role) => {
                return (
                  <tr key={role.role_id} className="bg-white dark:bg-gray-800">
                    <td className="px-6 py-4">{role.role_id}</td>
                    <td className="px-6 py-4">{role.role_name}</td>
                    <td className="px-6 py-4 text-center">
                      <Link
                        to=""
                        className="font-medium text-blue-600 dark:text-blue-500 hover:underline"
                      >
                        Chỉnh sửa
                      </Link>
                    </td>
                  </tr>
                );
              })
            )}
          </tbody>
        </table>
      </div>
    </div>
  );
};
