import { Form, required } from '../Context/Form';
import { Field } from '../Context/Field';
import { Link } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faSort } from '@fortawesome/free-solid-svg-icons';

export const RoleList = () => {
  return (
    <div>
      <p className="py-10 text-center font-bold text-slate-500">
        DANH SÁCH VAI TRÒ
      </p>
      <Form
        submitCaption="Thêm"
        onSubmit={() => {}}
        validationRules={{
          role_id: [{ validator: required }],
          role_name: [{ validator: required }],
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
              <th scope="col" className="px-6 py-3">
                <div className="flex items-center">
                  Product name
                  <FontAwesomeIcon
                    className="px-2 hover:cursor-pointer active:opacity-50"
                    icon={faSort}
                  />
                </div>
              </th>

              <th scope="col" className="px-6 py-3">
                <div className="flex items-center">
                  Color
                  <FontAwesomeIcon
                    className="px-2 hover:cursor-pointer active:opacity-50"
                    icon={faSort}
                  />
                </div>
              </th>
              <th scope="col" className="px-6 py-3">
                <span className="sr-only">Edit</span>
              </th>
            </tr>
          </thead>
          <tbody>
            <tr className="bg-white dark:bg-gray-800">
              <td className="px-6 py-4">Black</td>
              <td className="px-6 py-4">$99</td>
              <td className="px-6 py-4 text-right">
                <Link
                  to=""
                  className="font-medium text-blue-600 dark:text-blue-500 hover:underline"
                >
                  Edit
                </Link>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  );
};