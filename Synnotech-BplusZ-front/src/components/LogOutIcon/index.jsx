import React from 'react';
import { makeStyles } from '@material-ui/core/styles';

import { SvgIcon } from '@material-ui/core';

const useStyle = makeStyles((theme) => ({
  root: {
    fill: theme.palette.secondary.main,
    marginRight: theme.spacing(-0.4),
  },
}));

const LogOutIcon = () => {
  const classes = useStyle();
  return (
    <SvgIcon className={classes.root} viewBox="-5 -3 22 22">
      <path d="M12.6316 3.2L11.0526 3.2L11.0526 1.6L1.57895 1.6L1.57895 14.4L11.0526 14.4L11.0526 12.8L12.6316 12.8L12.6316 15.2C12.6316 15.4122 12.5484 15.6157 12.4003 15.7657C12.2523 15.9157 12.0515 16 11.8421 16L0.789473 16C0.580092 16 0.379285 15.9157 0.23123 15.7657C0.0831754 15.6157 -4.85052e-07 15.4122 -4.66504e-07 15.2L7.92384e-07 0.8C8.10933e-07 0.587826 0.0831767 0.384343 0.231232 0.234314C0.379287 0.0842845 0.580093 -3.06954e-07 0.789475 -2.88649e-07L11.8421 6.77602e-07C12.0515 6.95907e-07 12.2523 0.0842856 12.4003 0.234315C12.5484 0.384344 12.6316 0.587828 12.6316 0.800001L12.6316 3.2ZM11.0526 8.8L5.52632 8.8L5.52632 7.2L11.0526 7.2L11.0526 4.8L15 8L11.0526 11.2L11.0526 8.8Z" />
    </SvgIcon>
  );
};

export default LogOutIcon;
