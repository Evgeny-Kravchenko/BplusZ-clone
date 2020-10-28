import { makeStyles } from '@material-ui/core';

import { FONT_WEIGHT_MEDIUM } from '@/constants';

const useStyle = makeStyles((theme) => {
  return {
    containerPage: {
      flexDirection: 'column',
      padding: `${theme.spacing(3)} ${theme.spacing(6.4)} ${theme.spacing(3)} ${theme.spacing(
        7.9
      )}`,
    },
    goBackAndTitleContainer: {
      alignItems: 'center',
      paddingBottom: theme.spacing(3),
    },
    vehicleTitle: {
      paddingLeft: theme.spacing(1.5),
      fontSize: '2rem',
      fontWeight: FONT_WEIGHT_MEDIUM,
    },
    bodyContainer: {
      padding: `${theme.spacing(3)} 0 ${theme.spacing(3)}`,
    }
  };
});

export default useStyle;
