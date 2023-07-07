import React from 'react';
import { DeleteButton } from './DeleteButton';
import { PrimaryButton } from './PrimaryButton';

interface ModalProps {
  name: string;
  onConfirm: () => void;
  onCancel: () => void;
}

export const Modal = ({ name, onConfirm, onCancel }: ModalProps) => {
  return (
    <div>
      <div className="fixed top-0 left-0 w-full h-screen bg-gray-400 opacity-50 z-50"></div>
      <div className="fixed flex justify-center items-center h-screen w-full z-[70] top-0 left-0">
        <div className="h-36 xl:w-1/4 bg-white z-[70] w-1/2 rounded-md opacity-100">
          <p className="pt-5 font-bold text-center px-3">
            Bạn có chắc chắn muốn xóa vai trò{' '}
            <span className="text-red-700">{name}</span>
          </p>
          <div className="py-7 md:py-10 px-3 float-right">
            <DeleteButton title="Đồng ý" onClick={onConfirm}></DeleteButton>
            <PrimaryButton title="Hủy" onClick={onCancel} type="button" />
          </div>
        </div>
      </div>
    </div>
  );
};
