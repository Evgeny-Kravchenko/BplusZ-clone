import React from 'react';
import { useHistory } from 'react-router-dom';
import PropTypes from 'prop-types';

import { Button, IconButton, Popover, Box } from '@material-ui/core';
import MoreVertIcon from '@material-ui/icons/MoreVert';

import useStyle from './styles';

const AdditionalMenuGroup = ({ menuListConfig, id }) => {
  const classes = useStyle();
  const history = useHistory();

  const [anchorEl, setAnchorEl] = React.useState(null);

  const handleOpenAdditionalMenu = (event) => {
    setAnchorEl(event.currentTarget);
  };

  const handleCloseAdditionalMenu = () => {
    setAnchorEl(null);
  };

  const isOpenAdditionalMenu = Boolean(anchorEl);

  const handleButtonClick = (path) => {
    if (path) {
      history.push(`${path}/${id}`);
    }
  };

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
          {menuListConfig.map((button) => (
            <Button
              key={button.label}
              className={classes.button}
              id={id}
              onClick={() => handleButtonClick(button.path)}
            >
              {button.label}
            </Button>
          ))}
        </Box>
      </Popover>
    </>
  );
};

AdditionalMenuGroup.propTypes = {
  menuListConfig: PropTypes.arrayOf(PropTypes.instanceOf(Object)).isRequired,
  id: PropTypes.string.isRequired,
};

export default AdditionalMenuGroup;
