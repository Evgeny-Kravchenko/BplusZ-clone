import React from 'react';
import PropTypes from 'prop-types';
import { useHistory } from 'react-router-dom';

import { IconButton, Grid, Typography, CircularProgress } from '@material-ui/core';

import KeyboardBackspaceIcon from '@material-ui/icons/KeyboardBackspace';

import ContainerView from '@/components/ContainerView/ContainerView';
import CustomizedTabs from '@/components/Tabs';
import GeneralVehicleDataCard from '@/components/GeneralVehicleDataCard';
import TechicalComponentsVehicleDataCard from '@/components/TechicalComponentsVehicleDataCard';
import TechnicalContractDataVehicleDataCard from '@/components/TechnicalContractDataVehicleDataCard';
import TransferDataCard from '@/components/TransferDataCard/TransferDataCard';

import useVehicleDetails from '@/queries/useVehicleDetails/useVehicleDetails';

import useStyle from './styles';

const DetailsVehicleMain = ({ match }) => {
  const history = useHistory();
  const classes = useStyle();

  const { id } = match.params;

  const { data, isLoading, isError } = useVehicleDetails(id);

  const header = <CustomizedTabs />;

  const body = (
    <Grid container spacing={2} className={classes.bodyContainer}>
      <Grid item md={6}>
        <GeneralVehicleDataCard data={data?.generalData} />
      </Grid>
      <Grid item md={6}>
        <TechicalComponentsVehicleDataCard data={data?.technicalComponents} />
      </Grid>
      <Grid item md={6}>
        <TechnicalContractDataVehicleDataCard data={data?.technicalContractData} />
      </Grid>
      <Grid item md={6}>
        <TransferDataCard data={data?.transferData} />
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
          {data?.licenseNumber}
        </Typography>
      </Grid>
      <Grid item container className={classes.bodyContainer}>
        {isLoading && (
          <Grid item container className={classes.centeredContainer}>
            <CircularProgress color="secondary" />
          </Grid>
        )}
        {isError && !isLoading && (
          <Grid container>
            <Typography
              variant="body1"
              className={classes.noDataMessage}
              color="error"
            >
              Something went wrong on the server. Try again later.
            </Typography>
          </Grid>
        )}
        {!isLoading && !isError && <ContainerView header={header} body={body} />}
      </Grid>
    </Grid>
  );
};

DetailsVehicleMain.propTypes = {
  match: PropTypes.instanceOf(Object).isRequired,
};

export default DetailsVehicleMain;
