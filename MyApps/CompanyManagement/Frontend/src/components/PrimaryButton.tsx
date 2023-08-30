interface Props {
  title: React.ReactNode;
  onClick?: () => void;
  type?: 'submit' | 'reset' | 'button' | undefined;
}

export const PrimaryButton: React.FC<Props> = ({
  title,
  onClick,
  type = 'button',
}: Props) => {
  return (
    <button
      type={type}
      onClick={onClick}
      className="text-white border-white border tracking-wider border-solid rounded-md font-bold py-1.5 px-3 hover:text-slate-400 hover:bg-white hover:shadow-[0_0_30px_white] text-xs lg:text-sm transition-all duration-200"
    >
      {title}
    </button>
  );
};
