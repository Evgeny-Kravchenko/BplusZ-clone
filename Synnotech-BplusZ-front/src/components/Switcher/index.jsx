import React, { useState } from 'react';
import { useTranslation } from 'react-i18next';
import PropTypes from 'prop-types';

import { Switch, Box, Typography } from '@material-ui/core';

import useStyle from './styles';

const Switcher = (props) => {
  const { onChange } = props;
  const [isVorlauf, setVorlauf] = useState(true);
  const classes = useStyle();
  const { t } = useTranslation();

  const handleVorlaufSwitcher = () => {
    setVorlauf(!isVorlauf);
    onChange();
  };

  return (
    <div className={classes.switcherContainer}>
      <Box className={classes.labelsContainer} onClick={handleVorlaufSwitcher}>
        <Typography
          variant="body2"
          className={`${classes.label} ${!isVorlauf ? classes.active : ''}`}
        >
          {t('mainPage.switcherVorlauf')}
        </Typography>
        <Typography
          variant="body2"
          className={`${classes.label} ${isVorlauf ? classes.active : ''}`}
        >
          {t('mainPage.switcherBestand')}
        </Typography>
      </Box>
      <Switch
        checked={isVorlauf}
        onChange={handleVorlaufSwitcher}
        classes={{
          root: classes.switcherRoot,
          thumb: classes.switcherThumb,
          switchBase: classes.switcherSwitchBase,
          track: classes.switcherTrack,
        }}
        className={classes.switcherSwitchBase}
      />
    </div>
  );
};

Switcher.propTypes = {
  onChange: PropTypes.func.isRequired,
};

export default Switcher;
