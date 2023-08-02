import React from 'react';
import { Navigate, Outlet } from 'react-router-dom';
import { useAuth } from '../Context/Authorization';
import Navbar from '../Navbar/Navbar';

const PrivateRoute = () => {
  const { userLogin } = useAuth();

  if (!userLogin) {
    return <Navigate to="/login" />;
  }

  return (
    <div>
      <Navbar></Navbar>
      <div className="h-full pt-12">
        <Outlet />
      </div>
    </div>
  );
};

export default PrivateRoute;
