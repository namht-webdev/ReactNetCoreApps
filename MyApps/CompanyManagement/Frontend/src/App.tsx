import { Routes, Route, useNavigate } from 'react-router-dom';
// import Student from './components/Student/Student';
import HomePage from './components/Home/HomePage';
import { UserList } from './components/User/UserList';
import NotFound from './components/NotFound';
import { RoleList } from './components/Role/RoleList';
import LevelList from './components/Level/LevelList';
import { LevelAction } from './components/Level/LevelAction';
import { DepartmentList } from './components/Department/DepartmentList';
import { DepartmentAction } from './components/Department/DepartmentAction';
import { RequirementList } from './components/Requirement/RequirementList';
import { ScheduleList } from './components/Schedule/ScheduleList';
import { ScheduleAction } from './components/Schedule/ScheduleAction';
import { UserAction } from './components/User/UserAction';
import { useAuth } from './components/Context/Authorization';
import { useEffect } from 'react';
import { Login } from './components/UserStatus/Login';
import PrivateRoute from './components/UserStatus/PrivateRoute';
import CommonRoute from './components/UserStatus/CommonRoute';
import { RequirementAction } from './components/Requirement/RequirementAction';
import { RoleAction } from './components/Role/RoleAction';

function App() {
  const { userLogin } = useAuth();
  const navigate = useNavigate();
  useEffect(() => {
    if (!userLogin) {
      navigate('/login');
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [userLogin]);
  return (
    <div className="h-full">
      <Routes>
        <Route path="login" element={<Login />}></Route>
        <Route element={<CommonRoute />}>
          <Route path="/" element={<HomePage />}></Route>
          <Route path="requirement" element={<RequirementList />}></Route>
          <Route
            path="requirement/update/:requirement_id"
            element={<RequirementAction />}
          />
          <Route
            path="requirement/create"
            element={<RequirementAction />}
          ></Route>

          <Route path="schedule" element={<ScheduleList />}></Route>
          <Route
            path="schedule/update/:schedule_id"
            element={<ScheduleAction />}
          />
          <Route path="schedule/create" element={<ScheduleAction />}></Route>
        </Route>
        <Route element={<PrivateRoute />}>
          <Route path="user" element={<UserList />}></Route>
          <Route path="user/create" element={<UserAction />}></Route>
          <Route path="user/update/:user_id" element={<UserAction />}></Route>

          <Route path="role" element={<RoleList />}></Route>
          <Route path="role/update/:role_id" element={<RoleAction />} />
          <Route path="role/create" element={<RoleAction />}></Route>

          <Route path="level" element={<LevelList />}></Route>
          <Route path="level/update/:level_id" element={<LevelAction />} />
          <Route path="level/create" element={<LevelAction />}></Route>

          <Route path="department" element={<DepartmentList />}></Route>
          <Route
            path="department/update/:department_id"
            element={<DepartmentAction />}
          />
          <Route
            path="department/create"
            element={<DepartmentAction />}
          ></Route>
        </Route>

        <Route path="*" element={<NotFound />}></Route>
      </Routes>
    </div>
  );
}

export default App;
