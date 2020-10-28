import { makeStyles } from '@material-ui/core/styles';

const useStyle = makeStyles((theme) => ({
  root: {
    width: '230px',
    height: '36px',
    paddingLeft: '1.3rem',
    paddingRight: '1.3rem',
    borderRadius: '2px',
    backgroundColor: theme.palette.primary.light,
    opacity: '0.5',
  },
  input: {
    paddingLeft: '2.1rem',
  },
  underline: {
    '&&&:before': {
      borderBottom: 'none',
    },
    '&&:after': {
      borderBottom: 'none',
    },
  },
}));

export default useStyle;
