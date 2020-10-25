import { makeStyles } from '@material-ui/core/styles';

import { FONT_WEIGHT_MEDIUM } from '@/constants';

const useStyle = makeStyles((theme) => ({
  switcherContainer: {
    position: 'relative',

    '& .MuiSwitch-colorSecondary.Mui-checked + .MuiSwitch-track': {
      backgroundColor: 'transparent',
    },
  },
  switcherRoot: {
    width: 122,
    height: 26,
    padding: 0,
    borderRadius: '15px',
    backgroundColor: theme.palette.primary.light,
  },
  switcherThumb: {
    width: 61,
    height: 26,
    borderRadius: '15px',
  },
  switcherSwitchBase: {
    position: 'relative',
    padding: 0,
    color: theme.palette.info.dark,
    '& .MuiSwitch-switchBase.Mui-checked': {
      transform: 'translateX(61px)',
      color: theme.palette.info.dark,
    },
  },
  switcherTrack: {
    backgroundColor: theme.palette.primary.light,
  },
  labelsContainer: {
    position: 'absolute',
    top: '5px',
    left: '0',
    display: 'flex',
    justifyContent: 'space-around',
    width: 122,
    height: 26,
    zIndex: 1,
    cursor: 'pointer',
    userSelect: 'none',
  },
  label: {
    fontSize: '1.2rem',
    fontWeight: FONT_WEIGHT_MEDIUM,
    color: 'grey',
  },
  active: {
    color: theme.palette.primary.main,
  },
}));

export default useStyle;
