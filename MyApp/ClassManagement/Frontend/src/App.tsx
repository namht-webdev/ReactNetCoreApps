import { Routes, Route } from 'react-router-dom';
import Student from './components/Student/Student';
function App() {
  return (
    <Routes>
      <Route path="student/:studentId" element={<Student />}></Route>
    </Routes>
  );
}

export default App;
