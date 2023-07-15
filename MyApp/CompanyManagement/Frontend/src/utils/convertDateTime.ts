export const dateShowFm = (dateString: string) => {
  const date = dateString.split('T')[0];
  return date.split('-').reverse().join('/');
};

export const dateSaveFm = (dateString: string) => {
  return dateString.split('/').reverse().join('-');
};
