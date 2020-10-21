import { makeStyles } from '@material-ui/core';

import backgroundImageSrc from '@/assets/images/login-background.jpg';
import { PREVIEW_GRID_BG, DISGUISE_BG } from '@/constants';

export const useContainerStyles = makeStyles({
  root: {
    width: '100%',
    height: '100%',
  },
});

export const useAuthFormGridStyles = makeStyles({
  root: {
    position: 'relative',
    backgroundImage: `url(${backgroundImageSrc})`,
    backgroundRepeat: 'no-repeat',
    backgroundSize: 'cover',

    '&>.disguiseStyles': {
      position: 'absolute',
      width: '100%',
      height: '100%',
      backgroundColor: DISGUISE_BG,
      opacity: '0.85',
      zIndex: 1,
    },
  },
});

export const usePreviewGridStyles = makeStyles((theme) => ({
  root: {
    backgroundColor: PREVIEW_GRID_BG,
    padding: theme.spacing(2),
    [theme.breakpoints.up('xl')]: {
      padding: theme.spacing(7),
    },
  },
}));
