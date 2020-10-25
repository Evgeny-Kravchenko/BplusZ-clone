import React from 'react';
import { makeStyles, withStyles } from '@material-ui/core/styles';
import { Badge, IconButton } from '@material-ui/core';

import FilterIcon from '@/components/FilterIcon';

const StyledBadge = withStyles({
  badge: {
    top: 15,
    right: 6,
    padding: '0 4px',
    transform: 'scale(0.5) translate(50%, -50%)',
  },
})(Badge);

const useButtonIconStyle = makeStyles((theme) => ({
  root: {
    paddingLeft: theme.spacing(0),
    '&:hover': {
      backgroundColor: 'transparent',
    },
  },
}));

export default function FilterBadge() {
  const classes = useButtonIconStyle();
  return (
    <IconButton className={classes.root} aria-label="cart" size="small" disableRipple>
      <StyledBadge variant="dot" color="secondary">
        <FilterIcon />
      </StyledBadge>
    </IconButton>
  );
}
