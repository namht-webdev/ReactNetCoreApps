import {
  faLayerGroup,
  faSignOut,
  faUser,
  faUsers,
  faUserLock,
  faEnvelope,
  faCalendar,
  faHome,
} from '@fortawesome/free-solid-svg-icons';

import { useNavigate } from 'react-router-dom';
import { useAuth } from '../Context/Authorization';
import { NavItem } from './NavItem';
import { Fragment } from 'react';

const NavBar = ({ isHomePage }: { isHomePage?: boolean }) => {
  const { setUserLogin, authUser } = useAuth();
  const navigate = useNavigate();
  const handleLogout = () => {
    if (setUserLogin) {
      setUserLogin(false);
      localStorage.removeItem('access_token');
      localStorage.removeItem('user');
    }
    navigate('/login');
  };
  return (
    <div
      className={`flex items-center hidNav ${
        isHomePage
          ? 'h-screen'
          : 'fixed md:w-full bottom-0 mx-auto sm:justify-center h-full md:h-auto'
      }`}
    >
      <div
        className={`max-w-full lg:py-3 p-3 ${
          isHomePage ? 'mx-auto' : 'h-full'
        }`}
      >
        <div
          className={`grid home-nav h-full items-center ${
            isHomePage
              ? 'gap-10 sm:grid-cols-2 md:grid-cols-3 md:gap-20 xl:gap-32'
              : `py-20 md:pb-3 justify-center gap-7 md:gap-10 xl:gap-12 ${
                  authUser?.role_id === 'admin'
                    ? ' md:grid-cols-8'
                    : ' md:grid-cols-4'
                }`
          }`}
        >
          {!isHomePage && (
            <NavItem url="/" navIcon={faHome} title="trang chủ" />
          )}
          {authUser?.role_id === 'admin' && (
            <Fragment>
              <NavItem url="/user" navIcon={faUser} title="người dùng" />
              <NavItem url="/role" navIcon={faUserLock} title="vai trò" />
              <NavItem url="/department" navIcon={faUsers} title="bộ phận" />
              <NavItem url="/level" navIcon={faLayerGroup} title="chức vụ" />
            </Fragment>
          )}
          <NavItem url="/requirement" navIcon={faEnvelope} title="yêu cầu" />
          <NavItem url="/schedule" navIcon={faCalendar} title="lịch làm việc" />
          <NavItem
            url="/login"
            navIcon={faSignOut}
            title="đăng xuất"
            signOut={handleLogout}
            isLogout={isHomePage}
          />
        </div>
      </div>
    </div>
  );
};

export default NavBar;
