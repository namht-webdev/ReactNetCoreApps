import React, { useState, createContext, FormEvent } from 'react';
import { PrimaryButton } from '../PrimaryButton';
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
  error?: Errors;
}
interface Props {
  submitCaption?: string;
  children?: React.ReactNode;
  type?: 'submit';
  validationRules?: ValidationProp;
  onSubmit: (value: Values) => Promise<SubmitResult> | void;
  submitResult?: SubmitResult;
  successMessage?: string;
  failureMessage?: string;
}

export const Form: React.FC<Props> = ({
  submitCaption,
  children,
  type = 'submit',
  validationRules,
  onSubmit,
  submitResult,
  successMessage = 'Successed',
  failureMessage = 'Something went wrong',
}) => {
  const [values, setValues] = useState<Values>({});
  const [errors, setErrors] = useState<Errors>({});
  const [touched, setTouched] = useState<Touched>({});
  const [submitting, setSubmitting] = useState(false);
  const [submitted, setSubmitted] = useState(false);
  const [submitError, setSubmitError] = useState(false);

  const validate = (fieldName: string): string[] => {
    if (!validationRules || !validationRules[fieldName]) return [];
    const rules = Array.isArray(validationRules[fieldName])
      ? (validationRules[fieldName] as Validation[])
      : ([validationRules[fieldName]] as Validation[]);
    const fieldErrors: string[] = [];
    rules.forEach((rule) => {
      const error = rule.validator(values[fieldName], rule.args);
      if (error) fieldErrors.push(error);
    });

    const newErrors = { ...errors, [fieldName]: fieldErrors };
    setErrors(newErrors);
    return fieldErrors;
  };

  const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    if (validateForm()) {
      setSubmitting(true);
      setSubmitError(false);

      const result = await onSubmit(values);
      // The result may be passed through as a prop
      if (result === undefined) {
        return;
      }

      setErrors(result.error || {});
      setSubmitError(!result.success);
      setSubmitting(false);
      setSubmitted(true);
    }
  };

  const validateForm = () => {
    const newErrors: Errors = {};
    let haveErrors: boolean = false;
    if (validationRules) {
      Object.keys(validationRules).forEach((fieldName) => {
        newErrors[fieldName] = validate(fieldName);
        if (newErrors[fieldName]) {
          haveErrors = true;
        }
      });
    }
    return haveErrors;
  };

  const disabled = submitResult
    ? submitResult.success
    : submitting || (submitted && !submitError);
  const showError = submitResult
    ? !submitResult.success
    : submitted && submitError;
  const showSuccess = submitResult
    ? submitResult.success
    : submitted && !submitError;
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
        <fieldset disabled={disabled}>
          {children}
          <PrimaryButton type={type} title={submitCaption} />
          {showError && <p className="text-red-500">{failureMessage}</p>}
          {showSuccess && <p className="text-green-500">{successMessage}</p>}
        </fieldset>
      </form>
    </FormContext.Provider>
  );
};
