import { makeStyles } from '@material-ui/core';

const useStyle = makeStyles((theme) => {
  return {
    cardContainer: {
      flexDirection: 'column',
      alignItems: 'start',
      height: '320px',
      padding: `0 ${theme.spacing(1.6)} ${theme.spacing(2.9)} ${theme.spacing(1.6)}`,
      backgroundColor: theme.palette.primary.main,
      border: '1px solid #E5E5E5',
      borderRadius: '4px',
    },
    headerContainer: {
      alignItems: 'center',
      padding: theme.spacing(0.9),
      borderBottom: '1px solid #E5E5E5',
    },
    title: {
      fontSize: '1.8rem',
      paddingLeft: theme.spacing(1.4),
    },
    moreDetailsIcon: {
      '&:hover': {
        fill: theme.palette.secondary.main,
      },
    },
    bodyContainer: {
      paddingTop: theme.spacing(2.1),
      '& .MuiFormControl-root': {
        width: '100%',
      },
      '& .MuiInputBase-root.Mui-disabled': {
        color: theme.palette.primary.contrastText,
        paddingLeft: theme.spacing(1),
      },
      '& legend': {
        padding: `0 ${theme.spacing(1.5)}`,
      },
    },
  };
});

export default useStyle;
