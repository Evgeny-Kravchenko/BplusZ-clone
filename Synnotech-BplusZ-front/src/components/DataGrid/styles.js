import { makeStyles } from '@material-ui/core/styles';

const useStyle = makeStyles((theme) => ({
  dataContainer: {
    flexGrow: '1',
    flexDirection: 'column',
    padding: `${theme.spacing(3)} ${theme.spacing(3)} ${theme.spacing(3)} ${theme.spacing(3)}`,
    backgroundColor: theme.palette.primary.dark,
    [theme.breakpoints.up('lg')]: {
      padding: `${theme.spacing(3)} ${theme.spacing(6)} ${theme.spacing(3)} ${theme.spacing(8)}`,
    },
  },
  dataGridContainer: {
    flexGrow: '1',
    padding: `0 ${theme.spacing(2.9)} 0 ${theme.spacing(2.5)}`,
    backgroundColor: theme.palette.info.main,
  },
}));

export default useStyle;
