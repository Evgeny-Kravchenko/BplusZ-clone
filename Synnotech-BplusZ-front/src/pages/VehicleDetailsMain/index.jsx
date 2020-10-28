import React from 'react';
import { useHistory } from 'react-router-dom';

import { IconButton, Grid, Typography } from '@material-ui/core';

import KeyboardBackspaceIcon from '@material-ui/icons/KeyboardBackspace';

import ContainerView from '@/components/ContainerView/ContainerView';
import CustomizedTabs from '@/components/Tabs';

import useStyle from './styles';

const DetailsVehicleMain = () => {
  const history = useHistory();
  const classes = useStyle();

  const header = <CustomizedTabs />;

  return (
    <Grid container className={classes.containerPage}>
      <Grid container item className={classes.goBackAndTitleContainer}>
        <IconButton disableRipple color="secondary" size='small' onClick={() => history.goBack()}>
          <KeyboardBackspaceIcon />
        </IconButton>
        <Typography variant="h2" className={classes.vehicleTitle}>
          Fahrzeug BZ-LL 906
        </Typography>
      </Grid>
      <Grid item>
        <ContainerView header={header} body={<div>body</div>} />
      </Grid>
    </Grid>
  );
};

export default DetailsVehicleMain;
