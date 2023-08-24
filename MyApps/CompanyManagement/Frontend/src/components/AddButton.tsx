import { faPlusCircle } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { Link } from 'react-router-dom';

export const AddButton = () => {
  return (
    <div className="px-36">
      <Link to="create">
        <FontAwesomeIcon
          className="bg-slate-300 text-white rounded-full hover:text-slate-300 hover:bg-white hover:shadow-[0_0_50px_white] text-4xl transition-all duration-200"
          icon={faPlusCircle}
        />
      </Link>
    </div>
  );
};
