import React, { ChangeEvent, useState } from 'react';

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
    <div className="pt-20 text-center font-bold text-2xl text-slate-500">
      CUNG CẤP THÔNG TIN NHÂN VIÊN
      <hr className="mt-2 w-3/4 mx-auto border" />
      <div className="md:flex md:justify-between sm:px-32 px-10 text-lg pt-10">
        <div className="py-4 md:pr-3 pr-8">
          <input
            type="file"
            accept="image/*"
            onChange={handleImageChange}
            className="hidden"
            id="imageInput"
          />
          <label htmlFor="imageInput" className="cursor-pointer p-0">
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
        <div className="md:w-1/2 flex w-full text-base lg:text-lg">
          <ul className="text-start w-1/2">
            <li>User Id</li>
            <li>abc</li>
          </ul>
          <ul className="text-start w-1/2">
            <li>abc</li>
            <li>abc</li>
          </ul>
        </div>
      </div>
    </div>
  );
};
