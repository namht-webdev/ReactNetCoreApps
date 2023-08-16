import { faPlusCircle } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { Link } from 'react-router-dom';

export const AddButton = () => {
  return (
    <div className="px-36">
      <Link className="text-green-600 text-2xl" to="create">
        <FontAwesomeIcon icon={faPlusCircle} />
      </Link>
    </div>
  );
};
