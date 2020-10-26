import { makeStyles } from '@material-ui/core/styles';

import { FONT_WEIGHT_REGULAR } from '@/constants';

const useStyle = makeStyles((theme) => ({
  checkboxesContainer: {
    padding: theme.spacing(1.5),

    '& .MuiCheckbox-root': {
      paddingTop: theme.spacing(0),
      paddingBottom: theme.spacing(0),
      color: '#E4E4E4',

      '&.Mui-checked': {
        color: theme.palette.secondary.main,
      },
    },

    '& .MuiFormControlLabel-root': {
      '& :first-letter': {
        textTransform: 'uppercase',
      },
    },

    '& .MuiFormControlLabel-label': {
      fontSize: '1.2rem',
      fontWeight: FONT_WEIGHT_REGULAR,
      '& :first-letter': {
        textTransform: 'uppercase',
      },
    },
  },
}));

export default useStyle;
