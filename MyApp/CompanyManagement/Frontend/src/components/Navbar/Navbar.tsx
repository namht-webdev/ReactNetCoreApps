// import { useEffect } from 'react';
// import axios from 'axios';
// import { DEFAULT_API_URL } from '../../api/api';
import { useState } from 'react';
import { Link } from 'react-router-dom';
// import { appThemes } from '../../utils/Theme';
// type Theme = 'light' | 'dark';
const Navbar = () => {
  // useEffect(() => {
  //   axios.get(`${DEFAULT_API_URL}/api/Student/1`).then((res) => {
  //     console.log(res);
  //   });
  // }, []);
  const [toggleBtn, setToggleBtn] = useState(false);
  // const theme: Theme = 'dark';
  // const setTheme = useMemo(
  //   () => (theme === 'dark' ? appThemes.darkTheme : appThemes.lightTheme),
  //   [],
  // );
  return (
    <div>
      <nav className="bg-gray-500 text-slate-100 fixed flex items-center w-full">
        <div className="absolute top-0 p-3 sm:relative sm:top-0 w-full sm:w-auto bg-gray-500 text-white ">
          <span className="text-black">logo</span>
          <button
            onClick={() => setToggleBtn(!toggleBtn)}
            className="float-right px-3 inline sm:hidden text-black"
          >
            btn
          </button>
        </div>
        <ul
          className={`${
            toggleBtn ? 'h-0 overflow-hidden' : ''
          }  sm:h-auto mt-2 sm:mt-0 flex font-bold flex-col sm:flex-row sm:items-center pt-10 sm:pt-0 w-full justify-center`}
        >
          <li>
            <Link to="/">Home</Link>
          </li>
          <li>
            <Link to="user">User</Link>
          </li>
          <li>
            <Link to="user">Student</Link>
          </li>
          <li>
            <Link to="user">Class</Link>
          </li>
          <li>
            <Link to="user">Subject</Link>
          </li>
          <li className="p-3 sm:absolute sm:right-0">
            <Link to="user">Login</Link>
          </li>
        </ul>
      </nav>
    </div>
  );
};

export default Navbar;