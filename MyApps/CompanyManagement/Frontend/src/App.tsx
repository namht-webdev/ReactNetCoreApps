import { Routes, Route, useNavigate } from 'react-router-dom';
// import Student from './components/Student/Student';
import HomePage from './components/Home/HomePage';
import { UserList } from './components/User/UserList';
import NotFound from './NotFound';
import { RoleList } from './components/Role/RoleList';
import { CreateRole } from './components/Role/CreateRole';
import { UpdateRole } from './components/Role/UpdateRole';
import LevelList from './components/Level/LevelList';
import { CreateLevel } from './components/Level/CreateLevel';
import { UpdateLevel } from './components/Level/UpdateLevel';
import { DepartmentList } from './components/Department/DepartmentList';
import { UpdateDepartment } from './components/Department/UpdateDepartment';
import { CreateDepartment } from './components/Department/CreateDepartment';
import { CreateRequirement } from './components/Requirement/CreateRequirement';
import { RequirementList } from './components/Requirement/RequirementList';
import { UpdateRequirement } from './components/Requirement/UpdateRequirement';
import { ScheduleList } from './components/Schedule/ScheduleList';
import { UpdateSchedule } from './components/Schedule/UpdateSchedule';
import { CreateSchedule } from './components/Schedule/CreateSchedule';
import { CreateUser } from './components/User/CreateUser';
import { UpdateUser } from './components/User/UpdateUser';
import { useAuth } from './components/Context/Authorization';
import { useEffect } from 'react';
import { Login } from './components/UserStatus/Login';
import PrivateRoute from './components/UserStatus/PrivateRoute';
import CommondRoute from './components/UserStatus/CommonRoute';
import { TableData } from './components/TableData';

function App() {
  const { userLogin } = useAuth();
  const navigate = useNavigate();
  useEffect(() => {
    if (!userLogin) {
      navigate('/login');
    }
  }, [userLogin]);
  return (
    <div className="h-full">
      <Routes>
        <Route path="login" element={<Login />}></Route>
        <Route element={<CommondRoute />}>
          <Route path="/" element={<HomePage />}></Route>
          <Route path="requirement" element={<RequirementList />}></Route>
          <Route
            path="requirement/:requirement_id"
            element={<UpdateRequirement />}
          />
          <Route
            path="requirement/create"
            element={<CreateRequirement />}
          ></Route>

          <Route path="schedule" element={<ScheduleList />}></Route>
          <Route path="schedule/:schedule_id" element={<UpdateSchedule />} />
          <Route path="schedule/create" element={<CreateSchedule />}></Route>
        </Route>
        <Route element={<PrivateRoute />}>
          <Route path="user" element={<UserList />}></Route>
          <Route path="user/create" element={<CreateUser />}></Route>
          <Route path="user/:user_id" element={<UpdateUser />}></Route>

          <Route path="role" element={<RoleList />}></Route>
          <Route path="role/:role_id" element={<UpdateRole />} />
          <Route path="role/create" element={<CreateRole />}></Route>

          <Route path="level" element={<LevelList />}></Route>
          <Route path="level/:level_id" element={<UpdateLevel />} />
          <Route path="level/create" element={<CreateLevel />}></Route>

          <Route path="department" element={<DepartmentList />}></Route>
          <Route
            path="department/:department_id"
            element={<UpdateDepartment />}
          />
          <Route
            path="department/create"
            element={<CreateDepartment />}
          ></Route>
        </Route>

        <Route path="*" element={<NotFound />}></Route>
      </Routes>
    </div>
  );
}

export default App;
