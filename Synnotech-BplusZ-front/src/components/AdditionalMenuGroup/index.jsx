import React, { useEffect, memo } from 'react';
import PropTypes from 'prop-types';

import { Button, IconButton, Popover, Box } from '@material-ui/core';
import MoreVertIcon from '@material-ui/icons/MoreVert';

import useStyle from './styles';

const AdditionalMenuGroup = ({ menuListConfig }) => {
  const classes = useStyle();

  const [anchorEl, setAnchorEl] = React.useState(null);

  const handleOpenAdditionalMenu = (event) => {
    setAnchorEl(event.currentTarget);
  };

  const handleCloseAdditionalMenu = () => {
    setAnchorEl(null);
  };

  const isOpenAdditionalMenu = Boolean(anchorEl);

  useEffect(() => {
    console.log(1);
  });

  return (
    <>
      <IconButton size="small" onClick={handleOpenAdditionalMenu}>
        <MoreVertIcon />
      </IconButton>
      <Popover
        open={isOpenAdditionalMenu}
        anchorEl={anchorEl}
        onClose={handleCloseAdditionalMenu}
        anchorOrigin={{
          vertical: 'bottom',
          horizontal: 'left',
        }}
        transformOrigin={{
          vertical: 'top',
          horizontal: 'right',
        }}
        elevation={2}
      >
        <Box className={classes.buttonsWrapper}>
          {menuListConfig.map((buttonName) => (
            <Button key={buttonName} className={classes.button}>
              {buttonName}
            </Button>
          ))}
        </Box>
      </Popover>
    </>
  );
};

AdditionalMenuGroup.propTypes = {
  menuListConfig: PropTypes.arrayOf(PropTypes.string).isRequired,
};

export default memo(AdditionalMenuGroup, () => {
  return true;
});
