export const dateShowFm = (dateString: string) => {
  if (dateString && dateString.includes('-')) {
    const date = dateString.split('T')[0];
    return date.split('-').reverse().join('/');
  }
  return dateString;
};

export const dateSaveFm = (dateString: string) => {
  return dateString.split('/').reverse().join('-');
};
