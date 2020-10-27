import { makeStyles } from '@material-ui/core/styles';
import { FONT_WEIGHT_MEDIUM } from '@/constants';

const useStyle = makeStyles((theme) => ({
  toolBar: {
    backgroundColor: theme.palette.primary.main,
    padding: `${theme.spacing(2)} ${theme.spacing(3)} ${theme.spacing(2)} ${theme.spacing(2)}`,
  },
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
