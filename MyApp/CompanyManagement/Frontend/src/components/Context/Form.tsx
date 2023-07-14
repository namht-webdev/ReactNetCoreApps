import React, { useState, createContext, FormEvent, useEffect } from 'react';
import { PrimaryButton } from '../PrimaryButton';
import { useNavigate } from 'react-router-dom';
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
    ? 'This must be populated'
    : '';

export const minLength: Validator = (value: any, length: number): string =>
  value && value.length < length
    ? `This must be at least ${length} characters`
    : '';
export const mustBeNumber: Validator = (value: any, length: number): string =>
  value && !value.toString().match(/^\d+$/) ? `This must be a number` : '';
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
  initialValues?: Values;
  validationRules?: ValidationProp;
  onSubmit: (value: Values) => Promise<SubmitResult>;
  submitResult?: SubmitResult;
  successMessage?: string;
  failureMessage?: string;
}

export const Form = ({
  submitCaption,
  children,
  type = 'submit',
  initialValues,
  validationRules,
  onSubmit,
  successMessage = 'Successed',
  failureMessage = 'Something went wrong',
}: Props) => {
  const [values, setValues] = useState<Values>({});
  const [errors, setErrors] = useState<Errors>({});
  const [touched, setTouched] = useState<Touched>({});
  const [submitted, setSubmitted] = useState(false);
  const [submitError, setSubmitError] = useState(false);
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
    if (validateForm()) {
      setSubmitError(false);
      const result = await onSubmit(values);
      setErrors(result.errors || {});
      setSubmitError(!result.success);
      setSubmitted(true);
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
    setValues(initialValues ? initialValues : {});
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
          <div className="flex justify-between w-1/4 lg:w-1/6">
            <PrimaryButton type={type} title={submitCaption} />
          </div>
          {submitted && submitError && (
            <p className="text-red-500 pt-3">{failureMessage}</p>
          )}
          {submitted && !submitError && (
            <p className="text-green-500 pt-3">{successMessage}</p>
          )}
        </fieldset>
      </form>
    </FormContext.Provider>
  );
};
