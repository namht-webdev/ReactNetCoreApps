import { faKey, faLevelUp, faUser } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import React from 'react';
import { Link } from 'react-router-dom';

const HomePage = () => {
  return (
    <div className="h-full w-full mx-auto md:w-3/4 lg:w-1/2 xl:w-1/3">
      <div className="h-full home-nav flex justify-center items-center space-x-20">
        <Link
          className="before:border-slate-200 after:border-slate-200 hover:shadow-[0_0_50px_white] hover:bg-white hover:text-slate-500"
          to="/user"
        >
          <FontAwesomeIcon className="text-4xl" icon={faUser} />
        </Link>
        <Link
          className="before:border-slate-200 after:border-slate-200 hover:shadow-[0_0_50px_white] hover:bg-white hover:text-slate-500"
          to="/user"
        >
          <FontAwesomeIcon className="text-4xl" icon={faKey} />
        </Link>
        <Link
          className="before:border-slate-200 after:border-slate-200 hover:shadow-[0_0_50px_white] hover:bg-white hover:text-slate-500"
          to="/user"
        >
          <FontAwesomeIcon className="text-4xl" icon={faLevelUp} />
        </Link>
      </div>
    </div>
  );
};

export default HomePage;
