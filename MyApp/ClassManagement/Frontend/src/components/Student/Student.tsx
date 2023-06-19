import { Student as StudentInterface } from '../../../interfaces/Student';
interface StudentProps {
  student?: StudentInterface;
}
const Student = ({ student }: StudentProps) => {
  return (
    <div className="p-24">
      <table className="w-full">
        <thead></thead>
        <tbody>
          <tr>
            <td className="w-1/2">Student ID</td>
            <td className="w-1/2">{student?.StudentId}</td>
          </tr>
          <tr>
            <td className="w-1/2">Student Name</td>
            <td className="w-1/2">{student?.FullName}</td>
          </tr>
        </tbody>
      </table>
    </div>
  );
};

export default Student;
