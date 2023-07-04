import React from 'react';
import Filter from '../Context/Filter';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faPlusCircle } from '@fortawesome/free-solid-svg-icons';
import { Link } from 'react-router-dom';

const UserList = () => {
  const headers = ['Id', 'Name', 'Role', 'Department', 'BirthDate'];
  return (
    <div className="sm:p-5 p-1">
      User List
      <div className="py-2">
        <Link to="/user/create" className="px-2 bg-white text-xl">
          <FontAwesomeIcon icon={faPlusCircle} />
        </Link>
      </div>
      <Filter headers={headers} />
      <div>
        <table className="w-full">
          <thead>
            <tr className="flex justify-between">
              {headers.map((header, index) => {
                return <th key={index}>{header}</th>;
              })}
            </tr>
          </thead>
        </table>
      </div>
    </div>
  );
};

export default UserList;
