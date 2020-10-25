import { makeStyles } from '@material-ui/core';

export const usePreviewGridStyle = makeStyles((theme) => ({
  root: {
    padding: theme.spacing(1),
    [theme.breakpoints.up('lg')]: {
      padding: theme.spacing(2.5),
    },
  },
}));

export const usePartnersGridStyles = makeStyles((theme) => ({
  root: {
    marginBottom: theme.spacing(1),

    '& img': {
      marginBottom: theme.spacing(2.2),
    },
  },
}));
