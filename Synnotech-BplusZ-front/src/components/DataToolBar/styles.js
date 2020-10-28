import { makeStyles } from '@material-ui/core/styles';
import { FONT_WEIGHT_MEDIUM } from '@/constants';

const useStyle = makeStyles((theme) => ({
  buttonsContainer: {
    display: 'flex',
    justifyContent: 'space-between',
    alignItems: 'center',
    minWidth: '450px',

    '& button': {
      textTransform: 'uppercase',
      fontWeight: FONT_WEIGHT_MEDIUM,
      letterSpacing: '1.25px',
      boxShadow: 'none',
      marginRight: theme.spacing(1),
    },
  },
  searchContainer: {
    display: 'flex',
    marginLeft: 'auto',
    alignItems: 'center',
  },
}));

export default useStyle;
