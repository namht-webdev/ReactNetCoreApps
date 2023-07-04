import { faBars, faXmark } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { useState } from 'react';
const Navbar = () => {
  const [toggleBtn, setToggleBtn] = useState(false);

  return (
    <div>
      <nav className="bg-gray-500 text-slate-100 fixed flex items-center w-full">
        <div className="absolute top-0 p-3 sm:relative sm:top-0 w-full sm:w-auto bg-gray-500 text-white ">
          <span className="text-black">logo</span>
          <button
            onClick={() => setToggleBtn(!toggleBtn)}
            className="float-right px-3 inline sm:hidden text-black"
          >
            <FontAwesomeIcon
              className={`transform duration-300 ease-in-out ${
                !toggleBtn ? 'rotate-90' : ''
              }`}
              icon={toggleBtn ? faBars : faXmark}
            />
          </button>
        </div>
        <ul
          className={`${
            toggleBtn ? 'h-0 overflow-hidden' : 'h-[17.5rem]'
          }  sm:h-auto transition-all duration-500 mt-2 sm:mt-0 flex font-bold flex-col sm:flex-row sm:items-center pt-10 sm:pt-0 w-full justify-center`}
        >
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
