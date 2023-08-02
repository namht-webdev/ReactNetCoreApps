import { Routes, Route } from 'react-router-dom';
// import Student from './components/Student/Student';
import Navbar from './components/Navbar/Navbar';
import HomePage from './components/Home/HomePage';
function App() {
  return (
    // <Routes>
    //   <Route path="student/:studentId" element={<Student />}></Route>
    // </Routes>
    <div className="h-full">
      <Navbar></Navbar>
      <div className="pt-12 h-full">
        <Routes>
          <Route path="/" element={<HomePage />} />
        </Routes>
      </div>
    </div>
  );
}

export default App;
