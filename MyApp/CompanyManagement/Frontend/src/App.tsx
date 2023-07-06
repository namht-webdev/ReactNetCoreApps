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
          <Route path="*" element={<NotFound />}></Route>
        </Routes>
      </div>
    </div>
  );
}

export default App;
