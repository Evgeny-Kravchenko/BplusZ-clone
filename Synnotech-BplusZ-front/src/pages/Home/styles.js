import { makeStyles } from '@material-ui/core/styles';
import logoBlockBgSrc from '@/assets/images/header-logo-bg.jpg';

const useStyles = makeStyles((theme) => ({
  pageContainer: {
    flexDirection: 'column',
    justifyContent: 'flex-start',
  },
  headerContainer: {
    width: '100%',
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

export default useStyles;
