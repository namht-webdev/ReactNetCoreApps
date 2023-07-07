import React, { MouseEventHandler } from 'react';
interface Props {
  title: React.ReactNode;
  onClick?: MouseEventHandler;
}

export const DeleteButton: React.FC<Props> = ({ title, onClick }: Props) => {
  return (
    <button
      onClick={onClick}
      type="button"
      className="mx-5 text-white bg-red-700 hover:bg-red-800 focus:ring-4 focus:outline-none focus:ring-red-300 font-medium rounded-lg text-sm px-3 py-2 text-center dark:bg-red-600 dark:hover:bg-red-700 dark:focus:ring-red-800"
    >
      {title}
    </button>
  );
};
