import { Routes, Route } from 'react-router-dom';
// import Student from './components/Student/Student';
import Navbar from './components/Navbar/Navbar';
import HomePage from './components/Home/HomePage';
import UserList from './components/User/UserList';
import NotFound from './NotFound';
import { Create } from './components/User/Create';
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

function App() {
  return (
    // <Routes>
    //   <Route path="student/:studentId" element={<Student />}></Route>
    // </Routes>
    <div>
      <Navbar></Navbar>
      <div className="pt-12">
        <Routes>
          <Route path="/" element={<HomePage />}></Route>
          <Route path="user" element={<UserList />}></Route>
          <Route path="user/create" element={<Create />}></Route>
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

          <Route path="requirement" element={<RequirementList />}></Route>
          <Route
            path="requirement/:requirement_id"
            element={<UpdateRequirement />}
          />
          <Route
            path="requirement/create"
            element={<CreateRequirement />}
          ></Route>
          <Route path="*" element={<NotFound />}></Route>
        </Routes>
      </div>
    </div>
  );
}

export default App;
