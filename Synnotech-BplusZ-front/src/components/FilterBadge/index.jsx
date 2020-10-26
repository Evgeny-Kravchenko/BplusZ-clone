import React, { useState } from 'react';
import PropTypes from 'prop-types';

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

const FilterBadge = ({ checkBoxesConfig, checkBoxesDefault, handleOnChangeCheckboxes }) => {
  const classes = useButtonIconStyle();
  const [anchorEl, setAnchorEl] = useState(null);

  const isInvisible = !Object.values(checkBoxesConfig).some((checkbox) => checkbox);

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
        <CheckboxesGroup
          checkBoxesConfig={checkBoxesConfig}
          checkBoxesDefault={checkBoxesDefault}
          handleOnChange={handleOnChangeCheckboxes}
        />
      </Popover>
    </>
  );
};

FilterBadge.propTypes = {
  checkBoxesConfig: PropTypes.instanceOf(Object).isRequired,
  checkBoxesDefault: PropTypes.instanceOf(Object).isRequired,
  handleOnChangeCheckboxes: PropTypes.func.isRequired,
};

export default FilterBadge;
