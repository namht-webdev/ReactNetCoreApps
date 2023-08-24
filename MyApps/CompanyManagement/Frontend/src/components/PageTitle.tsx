export const PageTitle = ({ title }: { title: string }) => {
  return (
    <p className="py-10 text-center font-bold text-slate-100 md:text-4xl text-xl">
      {title}
    </p>
  );
};
