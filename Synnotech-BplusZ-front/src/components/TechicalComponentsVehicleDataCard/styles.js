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
    checkBoxContainer: {
      paddingTop: theme.spacing(1),

      '& .MuiFormControlLabel-label': {
        color: theme.palette.primary.contrastText,
      },
    },
    checkboxTitle: {
      fontSize: theme.spacing(1.4),
      paddingTop: theme.spacing(2),
      color: theme.palette.primary.contrastText,
    },
    checkboxLabel: {
      paddingLeft: theme.spacing(1.3),
    },
  };
});

export default useStyle;
