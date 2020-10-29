import { makeStyles } from '@material-ui/core';

import { FONT_WEIGHT_MEDIUM } from '@/constants';

const useStyle = makeStyles((theme) => {
  return {
    containerPage: {
      flexDirection: 'column',
      flexGrow: '1',
      padding: `${theme.spacing(2)} ${theme.spacing(6.4)} ${theme.spacing(3)} ${theme.spacing(
        7.9
      )}`,
    },
    goBackAndTitleContainer: {
      alignItems: 'center',
    },
    vehicleTitle: {
      paddingLeft: theme.spacing(1.5),
      fontSize: '2rem',
      fontWeight: FONT_WEIGHT_MEDIUM,
    },
    bodyContainer: {
      flexGrow: '1',
      padding: `${theme.spacing(2)} 0 ${theme.spacing(3)}`,
    },
    centeredContainer: {
      justifyContent: 'center',
      alignItems: 'center',
    },
    noDataMessage: {
      display: 'flex',
      width: '100%',
      alignItems: 'center',
      justifyContent: 'center',
    },
  };
});

export default useStyle;
