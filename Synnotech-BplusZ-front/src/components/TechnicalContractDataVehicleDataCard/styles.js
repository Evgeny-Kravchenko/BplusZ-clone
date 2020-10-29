import { makeStyles } from '@material-ui/core';

const useStyle = makeStyles((theme) => {
  return {
    title: {
      fontSize: '1.8rem',
      paddingLeft: theme.spacing(1.4),
    },
    moreDetailsIcon: {
      '&:hover': {
        fill: theme.palette.secondary.main,
      },
    },
  };
});

export default useStyle;
