import {
  faLayerGroup,
  faSignOut,
  faUser,
  faUsers,
  faUserLock,
  faEnvelope,
  faCalendar,
} from '@fortawesome/free-solid-svg-icons';
import { NavItem } from './NavItem';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '../Context/Authorization';

const HomePage = () => {
  const { setUserLogin, authUser } = useAuth();
  const navigate = useNavigate();
  const handleLogout = () => {
    if (setUserLogin) {
      setUserLogin(false);
      sessionStorage.removeItem('access_token');
      sessionStorage.removeItem('user');
    }
    navigate('/login');
  };
  return (
    <div className="min-h-screen flex items-center">
      <div className="max-w-4xl mx-auto p-10">
        <div className="grid home-nav gap-10 sm:grid-cols-2 md:grid-cols-3 md:gap-20 xl:gap-32">
          <NavItem url="/user" navIcon={faUser} title="người dùng" />
          <NavItem url="/role" navIcon={faUserLock} title="vai trò" />
          <NavItem url="/department" navIcon={faUsers} title="bộ phận" />
          <NavItem url="/level" navIcon={faLayerGroup} title="chức vụ" />
          <NavItem url="/requirement" navIcon={faEnvelope} title="yêu cầu" />
          <NavItem url="/schedule" navIcon={faCalendar} title="đăng xuất" />
          <NavItem
            url="/login"
            navIcon={faSignOut}
            title="đăng xuất"
            signOut={handleLogout}
            isLogout
          />
        </div>
      </div>
    </div>
  );
};

export default HomePage;
