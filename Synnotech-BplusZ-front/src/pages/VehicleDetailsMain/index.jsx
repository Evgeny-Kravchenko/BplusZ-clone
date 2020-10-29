import React from 'react';
import { useHistory } from 'react-router-dom';

import { IconButton, Grid, Typography } from '@material-ui/core';

import KeyboardBackspaceIcon from '@material-ui/icons/KeyboardBackspace';

import ContainerView from '@/components/ContainerView/ContainerView';
import CustomizedTabs from '@/components/Tabs';
import GeneralVehicleDataCard from '@/components/GeneralVehicleDataCard';
import TechicalComponentsVehicleDataCard from '@/components/TechicalComponentsVehicleDataCard';
import TechnicalContractDataVehicleDataCard from '@/components/TechnicalContractDataVehicleDataCard';
import TransferDataCard from '@/components/TransferDataCard/TransferDataCard';

import useStyle from './styles';

const DetailsVehicleMain = () => {
  const history = useHistory();
  const classes = useStyle();

  const header = <CustomizedTabs />;

  const body = (
    <Grid container spacing={2} className={classes.bodyContainer}>
      <Grid item md={6}>
        <GeneralVehicleDataCard />
      </Grid>
      <Grid item md={6}>
        <TechicalComponentsVehicleDataCard />
      </Grid>
      <Grid item md={6}>
        <TechnicalContractDataVehicleDataCard />
      </Grid>
      <Grid item md={6}>
        <TransferDataCard />
      </Grid>
    </Grid>
  );

  return (
    <Grid container className={classes.containerPage}>
      <Grid container item className={classes.goBackAndTitleContainer}>
        <IconButton disableRipple color="secondary" size="small" onClick={() => history.goBack()}>
          <KeyboardBackspaceIcon />
        </IconButton>
        <Typography variant="h2" className={classes.vehicleTitle}>
          Fahrzeug BZ-LL 906
        </Typography>
      </Grid>
      <Grid item className={classes.bodyContainer}>
        <ContainerView header={header} body={body} />
      </Grid>
    </Grid>
  );
};

export default DetailsVehicleMain;
