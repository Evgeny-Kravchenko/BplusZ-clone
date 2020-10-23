import { makeStyles } from '@material-ui/core';

import { FONT_WEIGHT_MEDIUM } from '@/constants';

export const useStyleFormGrid = makeStyles((theme) => ({
  root: {
    zIndex: '5',
    backgroundColor: '#ffffff',
    borderRadius: '1rem',
    padding: `${theme.spacing(4.5)} ${theme.spacing(3.3)} ${theme.spacing(3)} ${theme.spacing(
      3.3
    )}`,

    [theme.breakpoints.up('lg')]: {
      width: '523px',
      padding: `${theme.spacing(6.5)} ${theme.spacing(5.3)} ${theme.spacing(5)} ${theme.spacing(
        5.3
      )}`,
      '& .MuiFormLabel-root': {
        paddingLeft: theme.spacing(2),
      },
      '& .MuiFormHelperText-root': {
        paddingLeft: theme.spacing(2),
      },
      '& .MuiInputBase-input': {
        fontSize: '1.6rem',
        paddingBottom: theme.spacing(2),
        paddingLeft: theme.spacing(2),
        '&::placeholder': {
          fontSize: '2rem',
        },
      },
    },
  },
  errorMessage: {
    height: '20px',
    marginBottom: theme.spacing(1),
    fontSize: '1rem',

    [theme.breakpoints.up('lg')]: {
      fontSize: '1.4rem',
    },
  },
}));

export const useStyleForTitle = makeStyles((theme) => ({
  root: {
    fontSize: '2rem',
    fontWeight: FONT_WEIGHT_MEDIUM,
    marginBottom: theme.spacing(5),
    textAlign: 'center',
    [theme.breakpoints.up('lg')]: {
      marginBottom: theme.spacing(7),
      paddingLeft: theme.spacing(2),
      fontSize: '2.4rem',
      textAlign: 'left',
    },
  },
}));

export const useStyleForBoxOfLink = makeStyles((theme) => ({
  root: {
    display: 'flex',
    justifyContent: 'flex-end',
    paddingTop: theme.spacing(0.7),
    marginBottom: theme.spacing(5),
    fontSize: '1.2rem',
    [theme.breakpoints.up('lg')]: {
      marginBottom: theme.spacing(6.5),
      fontSize: '1.4rem',
    },
  },
}));

export const useStyleForSubmitButton = makeStyles((theme) => ({
  root: {
    width: '100%',
    height: '4rem',
    borderRadius: '0.5rem',
    fontSize: '1.4rem',

    [theme.breakpoints.up('lg')]: {
      height: '60px',
      fontSize: '1.8rem',
    },
  },
}));

export const useStyleForFormField = makeStyles((theme) => ({
  root: {
    position: 'relative',
    '& .MuiFormHelperText-root': {
      width: '250px',
      position: 'absolute',
      left: '0',
      top: '4.5rem',
      fontSize: '1rem',
      [theme.breakpoints.up('xl')]: {
        fontSize: '1.2rem',
      },
    },
    [theme.breakpoints.up('lg')]: {
      '& .MuiFormHelperText-root': {
        width: '250px',
        position: 'absolute',
        left: '0',
        top: '6.5rem',
        fontSize: '1rem',
        [theme.breakpoints.up('lg')]: {
          fontSize: '1.2rem',
        },
      },
    },
  },
}));
