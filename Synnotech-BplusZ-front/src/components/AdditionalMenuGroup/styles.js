import { makeStyles } from '@material-ui/core/styles';

const useStyle = makeStyles((theme) => ({
  buttonsWrapper: {
    display: 'flex',
    flexDirection: 'column',
  },
  button: {
    display: 'flex',
    justifyContent: 'flex-start',
    height: '31px',
    paddingLeft: theme.spacing(1.3),
    paddingRight: theme.spacing(2.5),
    fontSize: '1.2rem',
    borderRadius: '0',
    '&:hover': {
      backgroundColor: 'rgba(226, 80, 37, 0.04)',
    },
  },
}));

export default useStyle;
