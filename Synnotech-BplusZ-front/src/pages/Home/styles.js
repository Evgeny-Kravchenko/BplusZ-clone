import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles((theme) => {
  return {
    pageContainer: {
      height: '100%',
      flexDirection: 'column',
      justifyContent: 'flex-start',
      backgroundColor: theme.palette.primary.dark,
    },
    headerContainer: {
      width: '100%',
    },
  };
});

export default useStyles;
