import { makeStyles } from '@material-ui/core/styles';
import logoBlockBgSrc from '@/assets/images/header-logo-bg.jpg';

const useStyle = makeStyles((theme) => ({
  dataContainer: {
    padding: `${theme.spacing(3)} ${theme.spacing(3)} ${theme.spacing(3)} ${theme.spacing(3)}`,

    [theme.breakpoints.up('lg')]: {
      padding: `${theme.spacing(3)} ${theme.spacing(6.4)} 0 ${theme.spacing(7.9)}`,
    },
  },
  dataGridContainer: {
    padding: `0 ${theme.spacing(2.9)} 0 ${theme.spacing(2.5)}`,
  },
  logoBlock: {
    position: 'relative',
    height: '142px',
    backgroundImage: `url(${logoBlockBgSrc})`,

    '&>.disguiseStyles': {
      position: 'absolute',
      width: '100%',
      height: '100%',
      backgroundColor: theme.palette.info.dark,
      opacity: '0.85',
      zIndex: 1,
    },
    '& .MuiTypography-h1': {
      display: 'flex',
      alignItems: 'center',
      paddingLeft: theme.spacing(3),
      color: theme.palette.primary.main,
      zIndex: 5,
      fontSize: theme.spacing(2.8),
      [theme.breakpoints.up('lg')]: {
        paddingLeft: theme.spacing(8),
      },
    },
  },
}));

export default useStyle;
