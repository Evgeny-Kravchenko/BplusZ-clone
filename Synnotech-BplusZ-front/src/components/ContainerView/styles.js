import { makeStyles } from '@material-ui/core';

const useStyle = makeStyles((theme) => {
  return {
    container: {
      flexDirection: 'column',
      flexWrap: 'nowrap',
      borderRadius: '4px',
      overflow: 'hidden',
    },
    header: {
      height: '81px',
      padding: `${theme.spacing(2)} ${theme.spacing(3)} ${theme.spacing(2)} ${theme.spacing(2)}`,
      backgroundColor: theme.palette.primary.main,
    },
    body: {
      backgroundColor: theme.palette.info.main,
    },
  };
});

export default useStyle;
