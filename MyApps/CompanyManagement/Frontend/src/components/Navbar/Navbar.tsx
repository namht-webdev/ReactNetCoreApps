// import { useEffect } from 'react';
// import axios from 'axios';
// import { DEFAULT_API_URL } from '../../api/api';
import {
  faBars,
  faBell,
  faRightFromBracket,
  faTimes,
} from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { useState, useContext, Fragment } from 'react';
import { Link } from 'react-router-dom';
import { AuthContext } from '../Context/Authorization';
// import { appThemes } from '../../utils/Theme';
// type Theme = 'light' | 'dark';
const Navbar = () => {
  const [toggleBtn, setToggleBtn] = useState(true);
  const { setUserLogin, authUser } = useContext(AuthContext);
  const handleLogout = () => {
    if (setUserLogin) {
      setUserLogin(false);
      sessionStorage.removeItem('access_token');
      sessionStorage.removeItem('user');
    }
  };
  return (
    <div>
      <nav className="bg-gray-500 text-slate-100 fixed flex items-center w-full z-50">
        <div className="absolute top-0 p-3 lg:relative md:top-0 w-full lg:w-auto bg-gray-500 text-white ">
          <span className="text-black">logo</span>
          <button
            onClick={() => setToggleBtn(!toggleBtn)}
            className="float-right px-3 inline lg:hidden text-black text-xl"
          >
            <FontAwesomeIcon icon={toggleBtn ? faBars : faTimes} />
          </button>
        </div>
        <ul
          className={`${
            toggleBtn ? 'h-0 overflow-hidden' : ''
          }  lg:h-auto mt-2 lg:mt-0 flex font-bold flex-col lg:flex-row lg:items-center pt-10 lg:pt-0 w-full justify-center`}
        >
          <li>
            <Link to="/">Home</Link>
          </li>
          {authUser?.role_id === 'admin' && (
            <Fragment>
              <li>
                <Link to="user">User</Link>
              </li>
              <li>
                <Link to="role">Role</Link>
              </li>
              <li>
                <Link to="level">Level</Link>
              </li>
              <li>
                <Link to="department">Department</Link>
              </li>
            </Fragment>
          )}
          <li>
            <Link to="requirement">Requirement</Link>
          </li>
          <li>
            <Link to="schedule">Schedule</Link>
          </li>

          <li className="p-3 lg:absolute lg:right-20">
            <Link to="">
              <FontAwesomeIcon
                className="text-red-500 hover:text-white"
                icon={faBell}
              />
              <span className="text-red-500 text-sm lg:absolute lg:top-2 right-1 top-[-12px] relative">
                5
              </span>
            </Link>
          </li>
          <li className="p-3 lg:absolute lg:right-0">
            <button onClick={handleLogout}>
              <FontAwesomeIcon icon={faRightFromBracket} />
            </button>
          </li>
        </ul>
      </nav>
      {/* <div className="footer"></div> */}
    </div>
  );
};

export default Navbar;
