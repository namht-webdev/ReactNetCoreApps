import React, { useState, createContext, FormEvent, useEffect } from 'react';
import { PrimaryButton } from '../PrimaryButton';
import { useNavigate } from 'react-router-dom';
import { dateFmFromServer, dateSaveFm } from '../../utils/convertDateTime';
export interface Values {
  [key: string]: any;
}
interface Errors {
  [key: string]: string[];
}

interface Touched {
  [key: string]: boolean;
}

interface FormContextProps {
  values: Values;
  setValue?: (fieldName: string, value: any) => void;
  errors: Errors;
  validate?: (fieldName: string) => void;
  touched: Touched;
  setTouched?: (fieldName: string) => void;
}

type Validator = (value: any, args: any) => string;

export const required: Validator = (value: any): string =>
  value === undefined || value === null || value === ''
    ? 'Trường này không được để trống'
    : '';

export const minLength: Validator = (value: any, length: number): string =>
  value && value.length < length
    ? `Trường này phải nhập tối thiểu ${length} ký tự`
    : '';

export const mustBeNumber: Validator = (value: any): string =>
  value && !value.toString().match(/^\d+$/) ? `Trường này phải là số` : '';

export const mustBeEmail: Validator = (value: any): string =>
  value && !value.toString().match(/^[a-z0-9._]+@gmail\.[a-z]{2,}$/)
    ? `Mail không đúng định dạng`
    : '';
export const mustPhoneNumber: Validator = (value: any): string =>
  value &&
  (value.length !== 10 ||
    !value.toString().match(/(0[3|5|7|8|9])+([0-9]{8})\b/g))
    ? `Không đúng định dạng sđt Việt Nam(10 chữ số)`
    : '';

interface Validation {
  validator: Validator;
  args?: any;
}

// title: [{ validator: required }, { validator: minLength, args: 10 }],

interface ValidationProp {
  [key: string]: Validation | Validation[];
}

export const FormContext = createContext<FormContextProps>({
  values: {},
  errors: {},
  touched: {},
});
export interface SubmitResult {
  success: boolean;
  errors?: Errors;
  redirectUrl?: string;
}
interface Props {
  submitCaption?: string;
  children?: React.ReactNode;
  type?: 'submit';
  initialValues?: Values | null;
  validationRules?: ValidationProp;
  onSubmit: (value: Values) => Promise<SubmitResult>;
  submitResult?: SubmitResult;
  failureMessage?: string;
}

export const Form = ({
  submitCaption,
  children,
  type = 'submit',
  initialValues,
  validationRules,
  onSubmit,
  failureMessage = 'Something went wrong',
}: Props) => {
  const [values, setValues] = useState<Values>({});
  const [errors, setErrors] = useState<Errors>({});
  const [touched, setTouched] = useState<Touched>({});
  const [submitted, setSubmitted] = useState(false);
  const [submitError, setSubmitError] = useState(false);
  const dateSavePattern = /^([0-9]{2})\/([0-9]{2})\/([0-9]{4})$/;

  const validate = (fieldName: string): string[] => {
    if (!validationRules) {
      return [];
    }
    if (!validationRules[fieldName]) {
      return [];
    }
    const rules = Array.isArray(validationRules[fieldName])
      ? (validationRules[fieldName] as Validation[])
      : ([validationRules[fieldName]] as Validation[]);
    const fieldErrors: string[] = [];
    rules.forEach((rule) => {
      const error = rule.validator(values[fieldName], rule.args);
      if (error) {
        fieldErrors.push(error);
      }
    });
    const newErrors = { ...errors, [fieldName]: fieldErrors };
    setErrors(newErrors);
    return fieldErrors;
  };

  const navigate = useNavigate();
  const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const valuesWithDate = values;
    initialValues &&
      Object.keys(initialValues).forEach((key) => {
        if (values[key] && values[key].toString().match(dateSavePattern)) {
          valuesWithDate[key] = dateSaveFm(values[key]);
        }
      });
    if (validateForm()) {
      setSubmitError(false);
      const result = await onSubmit(valuesWithDate);
      setErrors(result.errors || {});
      setSubmitError(!result.success);
      setSubmitted(true);
      if (!result.success && 'avatar' in values) {
      }
      if (result.success && result.redirectUrl) {
        navigate(result.redirectUrl);
      }
    }
  };

  const validateForm = () => {
    const newErrors: Errors = {};
    let haveError: boolean = false;
    if (validationRules) {
      Object.keys(validationRules).forEach((fieldName) => {
        newErrors[fieldName] = validate(fieldName);
        if (newErrors[fieldName].length > 0) {
          haveError = true;
        }
      });
    }
    setErrors(newErrors);
    return !haveError;
  };

  useEffect(() => {
    const dateShowPattern = /^([0-9]{4})-([0-9]{2})-([0-9]{2})$/;
    const valuesWithDate = initialValues;
    valuesWithDate &&
      Object.keys(initialValues).forEach((key) => {
        if (
          initialValues[key] &&
          dateFmFromServer(initialValues[key].toString()).match(dateShowPattern)
        ) {
          valuesWithDate[key] = dateFmFromServer(initialValues[key].toString());
        }
        if (initialValues[key] === null) {
          valuesWithDate[key] = '';
        }
      });
    setValues(valuesWithDate ? valuesWithDate : {});
  }, [initialValues]);

  return (
    <FormContext.Provider
      value={{
        values,
        setValue: (fieldName: string, value: any) =>
          setValues({ ...values, [fieldName]: value }),
        errors,
        validate,
        touched,
        setTouched: (fieldName: string) => {
          setTouched({ ...touched, [fieldName]: true });
        },
      }}
    >
      <form
        className="lg:px-36 md:px-32 px-10 xl:px-72 2xl:px-96"
        noValidate={true}
        onSubmit={handleSubmit}
      >
        <fieldset>
          {children}
          <div className="flex justify-between">
            <PrimaryButton type={type} title={submitCaption} />
          </div>
          {submitted && submitError && (
            <p className="text-red-500 pt-3">{failureMessage}</p>
          )}
        </fieldset>
      </form>
    </FormContext.Provider>
  );
};
