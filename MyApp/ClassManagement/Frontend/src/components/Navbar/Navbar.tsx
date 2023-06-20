// import { useEffect } from 'react';
// import axios from 'axios';
// import { DEFAULT_API_URL } from '../../api/api';
const Navbar = () => {
  // useEffect(() => {
  //   axios.get(`${DEFAULT_API_URL}/api/Student/1`).then((res) => {
  //     console.log(res);
  //   });
  // }, []);

  return (
    <div>
      <nav className="bg-gray-500 text-white fixed flex items-center w-full">
        <div className="absolute top-2 px-3 sm:relative sm:top-0 w-full sm:w-auto">
          <span className="text-black">logo</span>
          <span className="float-right px-3 inline sm:hidden text-black cursor-pointer">
            btn
          </span>
        </div>
        <ul className="flex font-bold flex-col sm:flex-row sm:items-center pt-10 sm:pt-0 w-full justify-center">
          <li>Home</li>
          <li>Teacher</li>
          <li>Student</li>
          <li>Class</li>
          <li>Subject</li>
        </ul>
      </nav>
    </div>
  );
};

export default Navbar;
