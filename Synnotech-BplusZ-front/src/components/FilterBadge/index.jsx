import React, { useState } from 'react';

import { makeStyles, withStyles } from '@material-ui/core/styles';
import { Badge, IconButton, Popover } from '@material-ui/core';

import FilterIcon from '@/components/FilterIcon';

import CheckboxesGroup from '@/components/CheckboxesGroup';

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

const FilterBadge = (props) => {
  const classes = useButtonIconStyle();
  const [anchorEl, setAnchorEl] = useState(null);
  const { tableBestandState, checkboxesListName } = props;
  const isInvisible = !Object.values(tableBestandState[checkboxesListName]).some(
    (checkbox) => checkbox
  );

  const handleOnClickOpen = (event) => {
    setAnchorEl(event.currentTarget);
  };

  const handleOnClickClose = () => {
    setAnchorEl(null);
  };

  const open = Boolean(anchorEl);

  return (
    <>
      <IconButton
        disableRipple
        className={classes.root}
        aria-label="cart"
        size="small"
        onClick={handleOnClickOpen}
      >
        <StyledBadge variant="dot" color="secondary" invisible={isInvisible}>
          <FilterIcon />
        </StyledBadge>
      </IconButton>
      <Popover
        anchorEl={anchorEl}
        anchorOrigin={{
          vertical: 'bottom',
          horizontal: 'center',
        }}
        transformOrigin={{
          vertical: 'top',
          horizontal: 'left',
        }}
        open={open}
        onClose={handleOnClickClose}
        elevation={2}
      >
        <CheckboxesGroup {...props} />
      </Popover>
    </>
  );
};

FilterBadge.propTypes = {};

export default FilterBadge;
