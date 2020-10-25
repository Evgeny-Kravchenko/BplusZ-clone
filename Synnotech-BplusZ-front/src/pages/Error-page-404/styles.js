import { makeStyles } from '@material-ui/core/styles';

import backgroundImageSrc from '@/assets/images/error-page-404-bg.jpg';

import { FONT_WEIGHT_MEDIUM, FONT_WEIGHT_REGULAR } from '@/constants';

const useStyle = makeStyles((theme) => ({
  errorPageContainer: {
    width: '100%',
    height: '100%',
    backgroundColor: 'red',
  },
  errorImageContainer: {
    position: 'relative',
    width: '65%',
    backgroundImage: `url(${backgroundImageSrc})`,
    backgroundSize: 'cover',

    '&>.disguiseStyles': {
      position: 'absolute',
      width: '100%',
      height: '100%',
      backgroundColor: theme.palette.info.dark,
      opacity: '0.85',
      zIndex: 1,
    },
  },
  messageErrorContainer: {
    justifyContent: 'center',
    alignContent: 'center',
    width: '35%',
    backgroundColor: theme.palette.primary.main,

    '& h1': {
      fontSize: '8rem',
      fontWeight: FONT_WEIGHT_MEDIUM,
      marginBottom: theme.spacing(1.8),
    },

    '& h3': {
      fontSize: '3rem',
      fontWeight: FONT_WEIGHT_MEDIUM,
      marginBottom: theme.spacing(1.5),
    },

    '& p': {
      fontSize: '1.6rem',
      fontWeight: FONT_WEIGHT_REGULAR,
      lineHeight: '2.8rem',
    },
  },
  messagePaper: {
    width: '300px',
    height: '300px',
    boxSizing: 'border-box',
  },
  buttonToMainPage: {
    marginTop: theme.spacing(3),
    boxSizing: 'border-box',
    padding: '0',
    paddingBottom: theme.spacing(0.5),
    fontSize: '1.6rem',
    fontWeight: FONT_WEIGHT_MEDIUM,
    borderRadius: '0',

    '& .MuiButton-label': {
      lineHeight: 1,
    },

    '&:hover': {
      background: 'none',
      borderBottom: `1px solid ${theme.palette.secondary.main}`,
    },

    '& .MuiSvgIcon-root': {
      fontSize: '1.6rem',
      marginLeft: theme.spacing(0.5),
    },
  },
}));

export default useStyle;
