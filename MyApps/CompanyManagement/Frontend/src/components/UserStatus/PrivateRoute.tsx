import React from 'react';
import { Navigate, Outlet } from 'react-router-dom';
import { useAuth } from '../Context/Authorization';
import Navbar from '../Navbar/Navbar';

const PrivateRoute = () => {
  const { userLogin, authUser } = useAuth();
  if (authUser?.role_id !== 'admin' || !userLogin)
    return <Navigate to="/notfound" />;

  return (
    <div className="h-full">
      <div className="h-full">
        <Outlet />
      </div>
      <Navbar></Navbar>
    </div>
  );
};

export default PrivateRoute;
