import { createMuiTheme, responsiveFontSizes } from '@material-ui/core/styles';

import 'fontsource-roboto/latin-400-normal.css';
import 'fontsource-roboto/latin-500-normal.css';
import 'fontsource-roboto/latin-700-normal.css';

import {
  PRIMARY_MAIN_COLOR,
  PRIMARY_DARK_COLOR,
  PRIMARY_LIGHT_COLOR,
  SECONDARY_MAIN_COLOR,
  INFO_MAIN_COLOR,
  INFO_DARK_COLOR,
  HTML_FONT_SIZE,
  FONT_WEIGHT_MEDIUM,
  FONT_WEIGHT_REGULAR,
  FONT_WEIGHT_BOLD,
} from '@/constants';

const theme = createMuiTheme({
  breakpoints: {
    values: {
      xs: 0,
      sm: 600,
      md: 960,
      lg: 1280,
      xl: 1920,
    },
  },
  palette: {
    primary: {
      main: PRIMARY_MAIN_COLOR,
      dark: PRIMARY_DARK_COLOR,
      light: PRIMARY_LIGHT_COLOR,
      contrastText: '#000000'
    },
    secondary: {
      main: SECONDARY_MAIN_COLOR,
    },
    info: {
      main: INFO_MAIN_COLOR,
      dark: INFO_DARK_COLOR,
    },
  },
  typography: {
    htmlFontSize: HTML_FONT_SIZE,
    h1: {
      fontWeight: FONT_WEIGHT_BOLD,
    },
    h4: {
      fontWeight: FONT_WEIGHT_MEDIUM,
    },
    body1: {
      fontSize: '1.4rem',
      lineHeight: '2.4',
      fontWeight: FONT_WEIGHT_MEDIUM,
    },
  },
  spacing: (factor) => `${factor}rem`,
  overrides: {
    MuiCssBaseline: {
      '@global': {
        html: {
          height: '100%',
          fontSize: '10px',
        },
        body: {
          height: '100%',
        },
        '#root': {
          height: '100%',
        },
      },
    },
    MuiButton: {
      root: {
        textTransform: 'none',
        fontWeight: FONT_WEIGHT_REGULAR,
      },
    },
    MuiLink: {
      root: {
        cursor: 'pointer',
      },
    },
    MuiInputBase: {
      input: {
        fontSize: '1.6rem',
        '&:-webkit-autofill': {
          WebkitBoxShadow: '0 0 0 1000px white inset',
        },
      },
    },
    MuiInputLabel: {
      root: {
        fontSize: '1.2rem',
        '@media screen and (min-width: 1920px)': {
          fontSize: '1.6rem',
        },
      },
    },
  },
});

export default responsiveFontSizes(theme);
