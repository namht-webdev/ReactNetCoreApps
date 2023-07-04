import { FC, useContext, ChangeEvent } from 'react';
import { FormContext } from './Form';

interface Option {
  name: string;
  value: string;
}
interface Props {
  name: string;
  label?: string;
  type?: 'Text' | 'TextArea' | 'Password' | 'Select';
  optionData?: Option[] | null;
  defaltOPtion?: string;
}

export const Field: FC<Props> = ({
  name,
  label,
  type = 'Text',
  optionData,
  defaltOPtion,
}) => {
  const { setValue, touched, validate, setTouched } = useContext(FormContext);
  const handleChange = (
    e:
      | ChangeEvent<HTMLInputElement>
      | ChangeEvent<HTMLTextAreaElement>
      | ChangeEvent<HTMLSelectElement>,
  ) => {
    if (setValue) {
      setValue(name, e.currentTarget.value);
    }
    if (touched[name] && validate) {
      validate(name);
    }
  };
  const handleBlur = () => {
    if (setTouched) setTouched(name);
    if (validate) validate(name);
  };
  return (
    <FormContext.Consumer>
      {({ values, errors }) => (
        <div className="relative z-0 w-full mb-6 group">
          {(type === 'Text' || type === 'Password') && (
            <input
              type={type.toLowerCase()}
              id={name}
              name={name}
              className="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer"
              value={values[name] === undefined ? '' : values[name]}
              onChange={handleChange}
              onBlur={handleBlur}
              placeholder=" "
            />
          )}
          {type === 'TextArea' && (
            <textarea
              id={name}
              name={name}
              className="field h-[100px]"
              value={values[name] === undefined ? '' : values[name]}
              onChange={handleChange}
              onBlur={handleBlur}
            />
          )}
          {type === 'Select' && (
            <select
              id={name}
              name={name}
              className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-md focus:ring-blue-500 focus:border-blue-500 block w-full px-2.5 py-2 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
              value={values[name] === undefined ? '' : values[name]}
              onChange={handleChange}
              onBlur={handleBlur}
            >
              <option selected>{defaltOPtion}</option>
              {optionData?.map((data, idx) => (
                <option key={idx} value={data.value}>
                  {data.name}
                </option>
              ))}
            </select>
          )}
          {label && (
            <label
              htmlFor={name}
              className="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6"
            >
              {label}
            </label>
          )}
          {errors[name] &&
            errors[name].length > 0 &&
            errors[name].map((error) => (
              <div className="text-[12px] text-red-500" key={error}>
                {error}
              </div>
            ))}
        </div>
      )}
    </FormContext.Consumer>
  );
};
