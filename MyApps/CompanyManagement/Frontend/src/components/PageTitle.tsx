import { useLocation } from 'react-router-dom';
import { AddButton } from './AddButton';

export const PageTitle = ({ title }: { title: string }) => {
  const location = useLocation();
  console.log(location);
  return (
    <div
      className={`flex items-center justify-center ${
        location.pathname.includes('user/') ? 'pt-3' : 'py-8'
      }`}
    >
      <p className="py-3 text-center font-bold text-slate-100 md:text-2xl text-sm">
        {title}
      </p>
      {!location.pathname.includes('create') &&
        !location.pathname.includes('update') && <AddButton />}
    </div>
  );
};
