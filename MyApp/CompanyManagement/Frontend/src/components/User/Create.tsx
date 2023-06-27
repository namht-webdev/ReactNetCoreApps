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
      <div className="flex justify-between sm:px-48 px-10 text-lg pt-10">
        <div className="py-4 w-1/2">
          <input
            type="file"
            accept="image/*"
            onChange={handleImageChange}
            className="hidden"
            id="imageInput"
          />
          <label htmlFor="imageInput" className="block mb-4 cursor-pointer">
            {selectedImage ? (
              <img
                src={selectedImage as string}
                alt="Selected"
                className="w-40 h-40 object-cover"
              />
            ) : (
              <div className="w-60 h-60 border border-gray-300 flex items-center justify-center">
                <span className="text-gray-400 text-lg">Chọn hình ảnh</span>
              </div>
            )}
          </label>
        </div>
        <ul className="text-start w-1/4">
          <li>abc</li>
          <li>abc</li>
        </ul>
        <ul className="text-start w-1/4">
          <li>abc</li>
          <li>abc</li>
        </ul>
      </div>
    </div>
  );
};
