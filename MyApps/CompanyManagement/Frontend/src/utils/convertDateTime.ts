export const dateShowFm = (dateString: string): string => {
  if (dateString && dateString.includes('-')) {
    const date = dateString.split('T')[0];
    return date.split('-').join('/');
  }
  return dateString;
};

export const dateSaveFm = (dateString: string): string => {
  return dateString.split('/').reverse().join('-');
};

export const dateFmFromServer = (dateString: string): string => {
  return dateString.split('T')[0];
};
