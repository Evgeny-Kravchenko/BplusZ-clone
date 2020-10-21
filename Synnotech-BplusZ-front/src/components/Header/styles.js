import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles((theme) => ({
  grow: {
    flexGrow: 1,

    '& .MuiPaper-elevation4': {
      padding: '0',
      boxShadow: 'none',
      borderBottom: '1px solid #BBBBBB',
      [theme.breakpoints.up('lg')]: {
        padding: `0 ${theme.spacing(3)} 0 ${theme.spacing(5)}`,
      },
    },
    '& .MuiAvatar-root': {
      width: theme.spacing(2),
      height: theme.spacing(2),
    },
    '& .MuiButtonBase-root': {
      fontSize: theme.spacing(1.4),
      letterSpacing: 0,
    },
  },
  partnersContainer: {
    width: '700px',
    justifyContent: 'space-between',
    alignItems: 'flex-end',
  },
  menu: {
    width: 'auto',
    minWidth: '215px',
    justifyContent: 'space-between',
  },
  logout: {
    width: '128px',
    height: '30px',
    paddingLeft: '1.6rem',
    justifyContent: 'flex-start',
    fontSize: '1.2rem',
  },
  paper: {
    '& .MuiPopover-paper': {
      boxShadow: '0px 0px 4px rgba(0, 0, 0, 0.12), 0px 2px 2px rgba(0, 0, 0, 0.08)',
    },
  },
  langMenu: {
    '& .MuiPopover-paper': {
      display: 'flex',
      flexDirection: 'column',
      boxShadow: '0px 0px 4px rgba(0, 0, 0, 0.12), 0px 2px 2px rgba(0, 0, 0, 0.08)',
    },
  },
  langItem: {
    width: '89px',
    height: '30px',
    justifyContent: 'flex-start',
  },
}));

export default useStyles;
