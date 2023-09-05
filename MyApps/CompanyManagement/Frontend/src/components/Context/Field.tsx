import { useContext, ChangeEvent, useState } from 'react';
import { FormContext } from './Form';

export interface Option {
  name: string;
  value: string;
}
interface Props {
  name: string;
  label?: string;
  isDisabled?: boolean;
  type?:
    | 'Text'
    | 'TextArea'
    | 'Password'
    | 'Select'
    | 'Date'
    | 'Hidden'
    | 'File'
    | 'Checkbox';
  optionData?: Option[] | null;
}

export const Field = ({
  name,
  label,
  isDisabled,
  type = 'Text',
  optionData,
}: Props) => {
  const { setValue, touched, validate, setTouched } = useContext(FormContext);
  const [passwordRemember, setPasswordRemember] = useState(
    localStorage.getItem('passwordRemember') === '1',
  );
  const handleChange = (
    e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement | HTMLSelectElement>,
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
        <div
          className={`relative z-0 w-full mb-3 group ${
            type === 'Hidden' ? 'hidden' : ''
          }`}
        >
          {label && type === 'TextArea' && (
            <label
              htmlFor={name}
              className="text-sm font-bold text-white -z-10 border-slate-400 focus:border-white focus:shadow-[0_0_50px_white]"
            >
              {label}
            </label>
          )}
          {(type === 'Text' || type === 'Password' || type === 'Hidden') && (
            <input
              type={type.toLowerCase()}
              id={name}
              name={name}
              className={
                type === 'Hidden'
                  ? ''
                  : 'block py-1.5 px-0 w-full text-sm font-bold text-white bg-transparent border-0 border-b-2 border-slate-400 focus:border-white appearance-none focus:outline-none focus:ring-0 peer '
              }
              value={values[name] === undefined ? '' : values[name]}
              onChange={handleChange}
              onBlur={handleBlur}
              placeholder=" "
              disabled={isDisabled}
              autoComplete="false"
            />
          )}
          {type === 'Date' && (
            <input
              type={type.toLowerCase()}
              id={name}
              name={name}
              className="block py-1.5 px-0 w-full font-bold text-white bg-transparent border-0 border-b-2 border-slate-400 focus:border-white appearance-none focus:outline-none focus:ring-0 peer"
              value={
                values[name] === undefined
                  ? new Date().toISOString().split('T')[0]
                  : values[name]
              }
              onChange={handleChange}
              onBlur={handleBlur}
              disabled={isDisabled}
            />
          )}
          {type === 'TextArea' && (
            <textarea
              id={name}
              name={name}
              className="h-[100px] box-border mb-[5px] py-1.5 px-[10px] border-solid border-[1px] rounded-[3px] bg-white text-slate-500 w-full focus:outline-none focus:ring-0 focus:border-blue-600 peer"
              value={values[name] === undefined ? '' : values[name]}
              onChange={handleChange}
              onBlur={handleBlur}
            />
          )}
          {type === 'Select' && (
            <select
              id={name}
              className="border font-bold text-white bg-slate-500 text-sm rounded-md border-slate-400 focus:border-white block w-full px-2.5 py-1.5"
              value={values[name] === undefined ? '' : values[name]}
              onChange={handleChange}
              onBlur={handleBlur}
            >
              <option value="">{label}</option>
              {optionData?.map((data, idx) => (
                <option
                  className="font-bold text-white"
                  key={idx}
                  value={data.value}
                >
                  {data.name}
                </option>
              ))}
            </select>
          )}
          {type === 'Checkbox' && (
            <input
              checked={passwordRemember}
              readOnly
              className="mb-3 w-5 h-5 peer"
              name={name}
              id={name}
              type="checkbox"
              onChange={() => {
                localStorage.setItem(
                  'passwordRemember',
                  Number(!passwordRemember).toString(),
                );
                setPasswordRemember(!passwordRemember);
              }}
            />
          )}
          {label &&
            type !== 'TextArea' &&
            type !== 'Select' &&
            type !== 'File' &&
            type !== 'Checkbox' && (
              <label
                htmlFor={name}
                className="absolute text-sm text-slate-200 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:[text-shadow:0_0_10px_white] peer-focus:font-bold peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6"
              >
                {label}
              </label>
            )}
          {label && type === 'Checkbox' && (
            <label
              className="absolute text-sm px-3 peer-checked:[text-shadow:0_0_10px_white] peer-checked:font-bold peer-placeholder-shown:translate-y-0 peer-checked:scale-75 duration-300 transform"
              htmlFor={name}
            >
              Nhớ mật khẩu
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
