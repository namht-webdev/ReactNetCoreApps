import React from 'react';
import { Navigate, Outlet, useLocation } from 'react-router-dom';
import { useAuth } from '../Context/Authorization';
import Navbar from '../Navbar/Navbar';

const CommonRoute = () => {
  const { userLogin } = useAuth();
  const location = useLocation();
  if (!userLogin) return <Navigate to="/login" />;
  return (
    <div className="h-full">
      <div className="h-full">
        <Outlet />
        <Navbar isHomePage={location.pathname === '/'}></Navbar>
      </div>
    </div>
  );
};

export default CommonRoute;
