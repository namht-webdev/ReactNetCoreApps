import { IconDefinition } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import React from 'react';
import { Link } from 'react-router-dom';

interface NavItemProps {
  navIcon: IconDefinition;
  title: string;
  url: string;
  isLogout?: boolean;
  signOut?: () => void;
}
export const NavItem = ({
  navIcon,
  title,
  url,
  isLogout,
  signOut,
}: NavItemProps) => {
  return (
    <Link
      className={`before:border-slate-200 after:border-slate-200 hover:shadow-[0_0_50px_white] hover:bg-white hover:text-slate-500 ${
        isLogout ? 'col-start-2 col-end-3' : ''
      } `}
      to={`${url}`}
      onClick={signOut}
    >
      <span className="text-xs absolute w-48 text-white font-bold h-full z-50 opacity-0 hover:opacity-100 top-[-1.5rem] pb-28 text-center">
        {title}
      </span>
      <FontAwesomeIcon className="text-4xl" icon={navIcon} />
    </Link>
  );
};
