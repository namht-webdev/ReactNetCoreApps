import React from 'react';
import { Navigate, Outlet, useLocation } from 'react-router-dom';
import { useAuth } from '../Context/Authorization';
import Navbar from '../Navbar/Navbar';

const CommonRoute = () => {
  const { userLogin } = useAuth();
  const location = useLocation();
  if (!userLogin) return <Navigate to="/login" />;
  console.log(location);
  return (
    <div className="h-full">
      {/* <Navbar></Navbar> */}
      <div className="h-full">
        <Outlet />
      </div>
    </div>
  );
};

export default CommonRoute;
