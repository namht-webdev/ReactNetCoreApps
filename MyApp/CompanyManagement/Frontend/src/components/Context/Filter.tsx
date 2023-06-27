import React from 'react';
interface HeaderProps {
  headers: string[];
}

const Filter = ({ headers }: HeaderProps) => {
  return (
    <ul className="pt-5 flex justify-between m-auto xl:w-3/4 w-full">
      {headers.map((header, index) => (
        <li key={index} className="text-center">
          {header}
          <input
            className="p-1 text-sm border-slate-300 outline-slate-400 rounded-md mx-2 border"
            type="text"
          />
        </li>
      ))}
    </ul>
  );
};

export default Filter;
