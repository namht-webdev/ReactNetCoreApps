import React, { ChangeEvent, useState } from 'react';
import { Form, minLength, required } from '../Context/Form';
import { Field } from '../Context/Field';
export const Create = () => {
  const [selectedImage, setSelectedImage] = useState<
    string | ArrayBuffer | null
  >(null);

  const handleImageChange = (event: ChangeEvent<HTMLInputElement>) => {
    const file = event.target.files?.[0];

    if (file) {
      const reader = new FileReader();
      reader.onload = () => {
        setSelectedImage(reader.result);
      };
      reader.readAsDataURL(file);
    }
  };
  return (
    <div>
      <p className="pt-10 text-center font-bold text-2xl text-slate-500">
        THÊM NHÂN VIÊN
      </p>
      <hr className="mt-2 w-3/4 mx-auto border" />
      <div className="px-10 text-lg py-10">
        <div className="text-center">
          <input
            type="file"
            accept="image/*"
            onChange={handleImageChange}
            className="hidden"
            id="imageInput"
          />
          <label
            htmlFor="imageInput"
            className="cursor-pointer p-0 inline-block w-auto"
          >
            {selectedImage ? (
              <img
                src={selectedImage as string}
                alt="Selected"
                className="sm:w-40 object-cover sm:h-40 w-28 h-28"
              />
            ) : (
              <div className="sm:w-60 sm:h-60 w-32 h-32 border border-gray-300 flex items-center justify-center">
                <span className="text-gray-400 text-lg">Chọn hình ảnh</span>
              </div>
            )}
          </label>
        </div>
      </div>

      <Form
        submitCaption="Thêm"
        onSubmit={() => {}}
        validationRules={{
          ahihi: [{ validator: required }, { validator: minLength, args: 10 }],
        }}
      >
        <Field name="ahihi" label="Họ tên"></Field>
        <div className="grid md:grid-cols-2 md:gap-6">
          <Field name="name" label="ahuhu"></Field>
          <Field name="name" label="ahuhu"></Field>
        </div>
        <div className="grid md:grid-cols-2 md:gap-6">
          <div className="grid md:grid-cols-2 md:gap-6">
            <Field name="name" label="ahuhu"></Field>
            <Field name="name" label="ahuhu"></Field>
          </div>
          <div className="grid md:grid-cols-2 md:gap-6">
            <Field name="name" label="ahuhu"></Field>
            <Field name="name" type="Select" defaltOPtion="Chọn tỉnh"></Field>
          </div>
        </div>
      </Form>
    </div>
  );
};
