import axios from 'axios';
import React, { ChangeEvent, FormEvent, useState } from 'react';
import { DEFAULT_API_URL } from '../../api/api';
import { PrimaryButton } from '../PrimaryButton';
import { DeleteButton } from '../DeleteButton';
//const { avatar } = require('../../../../Backend/uploads/avatar.jpg');

export const UploadAvatar = ({ src }: { src: string }) => {
  const [selectedImage, setSelectedImage] = useState<
    ArrayBuffer | null | string
  >(null);
  const [imageUpload, setImageUpload] = useState<File | null>(null);
  const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    if (imageUpload) {
      try {
        const formData = new FormData();
        formData.append('fileUpload', imageUpload);
        await axios.post<{ success: boolean }>(
          `${DEFAULT_API_URL}/user/upload?userId=namht`,
          formData,
        );
      } catch (error) {
        alert('Có lỗi xảy ra trong quá trình thực hiện');
      }
    }
  };
  const handleDelete = () => {
    setImageUpload(null);
    setSelectedImage(null);
  };
  const handleImageChange = (event: ChangeEvent<HTMLInputElement>) => {
    const file = event.target.files?.[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = () => {
        setSelectedImage(reader.result);
        setImageUpload(file);
      };
      reader.readAsDataURL(file);
    }
    event.target.value = '';
  };
  return (
    <div className="px-10 text-lg pb-10">
      <div className="text-center">
        <form noValidate={true} onSubmit={handleSubmit}>
          <input
            type="file"
            accept=".jpg, .png"
            onChange={handleImageChange}
            className="hidden"
            name="fileUpload"
            id="fileUpload"
          />
          <label
            htmlFor="fileUpload"
            className="cursor-pointer p-0 inline-block w-auto"
          >
            <img
              src={imageUpload !== null ? (selectedImage as string) : src}
              alt="Selected"
              className="sm:w-40 object-cover sm:h-40 w-28 h-28 rounded-full"
            />
          </label>
          <span className="mt-[-50px]">
            {imageUpload && (
              <div className="w-1/3 mx-auto flex justify-between md:w-1/6 xl:w-1/12">
                <PrimaryButton title="Lưu" type="submit" />
                <DeleteButton title="Xóa" onClick={handleDelete} />
              </div>
            )}
          </span>
        </form>
      </div>
    </div>
  );
};
